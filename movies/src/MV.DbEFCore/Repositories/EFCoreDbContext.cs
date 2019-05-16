using MV.DbEFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MV.DbEFCore.Repositories
{
    public class EfCoreDbContext : DbContext
    {
        public EfCoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //domain
            modelBuilder.ApplyConfiguration(new UserMapConfig());
        }
    }
}
