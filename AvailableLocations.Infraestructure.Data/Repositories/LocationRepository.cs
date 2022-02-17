using AvailableLocations.Domain;
using AvailableLocations.Domain.Interfaces.Repositories;
using AvailableLocations.Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvailableLocations.Infraestructure.Data.Repositories
{
    public class LocationRepository : IBaseRepository<Location, Guid>
    {
        /// <summary>
        /// Injection of DB
        /// </summary>
        private LocationContext db;

        public LocationRepository(LocationContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// Add Location Method
        /// </summary>
        /// <returns>A newly created Location</returns>
        public Location Add(Location entity)
        {
            entity.locationId = Guid.NewGuid();
            db.Locations.Add(entity);
            return entity;
        }

        /// <summary>
        /// List Location Method
        /// </summary>
        /// <returns>A full Location list or an empty list if the Table is empty</returns>
        public List<Location> List()
        {
            return db.Locations.ToList();
        }

        /// <summary>
        /// Method for Save Changes using the ORM
        /// </summary>
        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        /// <summary>
        /// List location with filter by range of availabiliy times
        /// </summary>
        /// <returns>A Location list that accomplish with the filter or an empty list if not exist any one that pass the filter</returns>
        public List<Location> SeleccionarByTimeRange(Location entity)
        {
            var selectedLocations = db.Locations.Where(c => c.locationOpenTime <= entity.locationOpenTime && c.locationCloseTime >= entity.locationCloseTime).ToList();
            return selectedLocations;
        }

        /// <summary>
        /// List location with filter by Id
        /// </summary>
        /// <returns>A Location that accomplish with the filter or nul if the Id not exist</returns>
        public Location SelectById(Guid entityId)
        {
            var selectedLocation = db.Locations.Where(c => c.locationId == entityId).FirstOrDefault();
            return selectedLocation;
        }
    }
}
