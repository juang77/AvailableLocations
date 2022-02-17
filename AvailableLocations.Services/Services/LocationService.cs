using AvailableLocations.Domain;
using AvailableLocations.Domain.Interfaces.Repositories;
using AvailableLocations.Services.Interfaces;
using System;
using System.Collections.Generic;


namespace AvailableLocations.Services.Services
{
    public class LocationService : IBaseService<Location, Guid>
    {
        private readonly IBaseRepository<Location, Guid> baseRepository;

        public LocationService(IBaseRepository<Location, Guid> _baseRepository) {
            baseRepository = _baseRepository;
        }

        /// <summary>
        /// Add Location Service
        /// </summary>
        /// <returns>A newly created Location</returns>
        public Location Add(Location entity)
        {
            if (entity == null)
                throw new ArgumentNullException("The 'location' is required");

            var resultLocation = baseRepository.Add(entity);
            baseRepository.SaveAllChanges();
            return resultLocation;
        }

        /// <summary>
        /// List Location Service
        /// </summary>
        /// <returns>A full Location list or an empty list if the Table is empty</returns>
        public List<Location> List()
        {
            return baseRepository.List();
        }

        /// <summary>
        /// Get Location By Id Service
        /// </summary>
        /// <returns>A Location list that accomplish with the filter or an empty list if not exist any one that pass the filter</returns>
        public List<Location> SeleccionarByTimeRange(Location entity)
        {
            var LocationsResult = baseRepository.SeleccionarByTimeRange(entity);
            return LocationsResult;
        }

        /// <summary>
        /// Get Location by Id Service
        /// </summary>
        /// <returns>A Location that accomplish with the filter or nul if the Id not exist</returns>
        public Location SelectById(Guid entityId)
        {
            return baseRepository.SelectById(entityId);
        }
    }
}
