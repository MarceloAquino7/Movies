using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MV.DbEFCore.Repositories
{
    public class EfCoreDbContextFactory : IDesignTimeDbContextFactory<EfCoreDbContext>
    {
       public EfCoreDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", false, true)                   
                   .AddEnvironmentVariables();

            var configuration = builder.Build();

            var context = new DbContextOptionsBuilder<EfCoreDbContext>();
            
            context.UseSqlServer(configuration.GetConnectionString("MVConnection"));

            return new EfCoreDbContext(context.Options);
        }
    }
}
