using AvailableLocations.Domain;
using AvailableLocations.Infraestructure.Data.Configs;
using Microsoft.EntityFrameworkCore;

namespace AvailableLocations.Infraestructure.Data.Context
{
    public class LocationContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Entity Framework Configuration - Connection
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=localhost;Initial Catalog=LocationsDB;Integrated Security = true;");
        }

        /// <summary>
        /// Builder Pattern for Entity Framework that allow to create the DB when this one not exist
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new LocationsConfig());
        }
    }
}
