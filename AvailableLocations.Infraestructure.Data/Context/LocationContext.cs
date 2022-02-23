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
            options.UseSqlServer(@"Data Source=tcp:availablelocationsinfraestructureapidbserver.database.windows.net,1433;Initial Catalog=AvailableLocations.Infraestructure.API_db;User Id=juang77@availablelocationsinfraestructureapidbserver;Password=Nicolas8032367");
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
