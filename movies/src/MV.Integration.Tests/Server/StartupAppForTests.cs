using System.Reflection;
using Autofac;
using MV.ApplicationService.InjectionModules;
using MV.DbEFCore.Repositories;
using MV.Infrastructure.InjectionModules;
using MV.Common.WebServer.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MV.Integration.Tests.Server
{
    public class StartupAppForTests
    {
        public StartupAppForTests(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        { 
            // IoC Container Module Registration
            builder.RegisterModule(new IoCModuleApplicationService());
            builder.RegisterModule(new IoCModuleInfrastructure());
            builder.RegisterModule(new IoCAutoMapperModule());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EfCoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MVConnection"));
            });

            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            }).AddApplicationPart(Assembly.Load("MV.WebApi"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IHttpContextAccessor accessor)
        {
            app.UseApiResponseWrapperMiddleware();
            app.UseMvc();
            UpdateDatabaseUsingEfCore(app);
        }

        private void UpdateDatabaseUsingEfCore(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var database = serviceScope
                    .ServiceProvider
                    .GetRequiredService<EfCoreDbContext>()
                    .Database;

                database.EnsureDeleted();
                database.Migrate();
            }
        }
    }
}
