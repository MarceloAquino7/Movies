using Autofac;
using MV.ApplicationService.Configuration;
using MV.Domain.Tests.Factories;
using Microsoft.Extensions.Configuration;

namespace MV.Domain.Tests.InjectionModules
{
    public class IoCModuleDomainTest : Module
    {
        public IoCModuleDomainTest()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();
        }

        public IConfigurationRoot Configuration { get; }

        protected override void Load(ContainerBuilder builder)
        {
            // Test Factories
            builder.RegisterType<UserFactory>().AsSelf();
        }
    }
}
