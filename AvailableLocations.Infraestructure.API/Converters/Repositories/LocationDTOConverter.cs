using AvailableLocations.Domain;
using AvailableLocations.Services.DTOs;
using System;

namespace AvailableLocations.Infraestructure.API.Converters
{
    public class LocationDTOConverter
    {
        // This is a Method for convert from main entity to a DTO with String in replace of TimeSpam
        public LocationDTO locationToDto(Location entity)
        {
            LocationDTO locationDTO = new LocationDTO();

            locationDTO.locationId = entity.locationId;
            locationDTO.locationName = entity.locationName;
            locationDTO.locationOpenTime = entity.locationOpenTime.ToString();
            locationDTO.locationCloseTime = entity.locationCloseTime.ToString();
            return locationDTO;
        }

        // This is a Method for convert from DTO to main entity with TimeSpam in replace of Strings
        public Location DtoToLocation(LocationDTO entity)
        {
            Location location = new Location();

            location.locationId = entity.locationId;
            location.locationName = entity.locationName;
            location.locationOpenTime = TimeSpan.Parse(entity.locationOpenTime);
            location.locationCloseTime = TimeSpan.Parse(entity.locationCloseTime);
            return location;
        }
}
}
