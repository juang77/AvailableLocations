using AvailableLocations.Domain;
using AvailableLocations.Services.DTOs;

namespace AvailableLocations.Infraestructure.API.Converters
{
    public interface ILocationDTOConverter
    {
        LocationDTO locationToDto(Location entity);
        Location DtoToLocation(LocationDTO entity);
    }
}
