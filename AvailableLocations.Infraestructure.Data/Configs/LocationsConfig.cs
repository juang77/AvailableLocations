using AvailableLocations.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvailableLocations.Infraestructure.Data.Configs
{
    class LocationsConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("tblLocations");
            builder.HasKey(c => c.locationId);
        }
    }
}
