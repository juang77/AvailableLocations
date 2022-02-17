using System;
using System.ComponentModel.DataAnnotations;

namespace AvailableLocations.Domain
{
    //This is the Main Object of the exercice - Location
    public class Location
    {

        public Guid locationId { get; set; }

        [Required]
        public string locationName { get; set; }

        [Required]
        public TimeSpan locationOpenTime { get; set; }

        [Required]
        public TimeSpan locationCloseTime { get; set; }
    }
}
