using Newtonsoft.Json;
using System;

namespace AvailableLocations.Services.DTOs
{
    //This is a DTO that allow the service to return string in replace of timespan for Open and Close time. 
    public class LocationDTO
    {

        [JsonProperty("id")]
        public Guid locationId { get; set; }

        [JsonProperty("name")]
        public string locationName { get; set; }

        [JsonProperty("opentime")]
        public string locationOpenTime { get; set; }

        [JsonProperty("closetime")]
        public string locationCloseTime { get; set; }
    }
}
