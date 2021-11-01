using Microsoft.EntityFrameworkCore;
using CDPN.Classifiers.Entities;
using System.Reflection;
using Microsoft.Extensions.Configuration;

// https://dev.to/moesmp/ef-core-multiple-database-providers-3gb7
// https://github.com/mo-esmp/ef-multiple-providers
// https://jasonwatmore.com/post/2021/06/03/net-5-entity-framework-migrations-for-multiple-databases-sqlite-and-sql-server


namespace CDPN.Classifiers.Infrastructure.Data
{
#nullable disable
    public class ClassifiersContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        protected ClassifiersContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ClassifiersContext(DbContextOptions<ClassifiersContext> options) : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<RegionLevel> RegionLevels { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PaperSize> PaperSizes { get; set; }

        public DbSet<AdminTerritorialCategory> AdminTerritorialCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.ApplyConfiguration(new Config.CurrencyConfiguration());
            builder.ApplyConfiguration(new Config.CountryConfiguration());
            builder.ApplyConfiguration(new Config.RegionLevelConfiguration());
            builder.ApplyConfiguration(new Config.RegionConfiguration());
            builder.ApplyConfiguration(new Config.PaperSizeConfiguration());
        }
    }
}
