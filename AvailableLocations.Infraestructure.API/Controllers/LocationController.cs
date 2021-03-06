using AvailableLocations.Domain;
using AvailableLocations.Infraestructure.API.Converters;
using AvailableLocations.Infraestructure.Data.Context;
using AvailableLocations.Infraestructure.Data.Repositories;
using AvailableLocations.Services.DTOs;
using AvailableLocations.Services.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;


namespace AvailableLocations.Infraestructure.API.Controllers
{
    [SwaggerTag("This API give user access to Locations")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class LocationController : Controller
    {
        //LocationDTOConverter LocConverter = new LocationDTOConverter();

        ILocationDTOConverter _locationDTOConverter;

        public LocationController(ILocationDTOConverter locationDTOConverter) {
            _locationDTOConverter = locationDTOConverter;
        }

        LocationService locationService(){
            LocationContext db = new LocationContext();
            LocationRepository repo = new LocationRepository(db);
            LocationService service = new LocationService(repo);
            return service;
        }


        // GET: api/<LocationController>
        /// <summary>
        /// Get Locations full list.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        /// </remarks>
        /// <returns>A full list of Locations</returns>
        /// <response code="200">Returns the list of Locations</response>
        /// <response code="204">If the item list null</response>      
        /// <response code="500">If exist any kind of error</response>      
        [EnableCors("AllowOrigin")]  
        [HttpGet]
        public ActionResult<List<LocationDTO>> Get()
        {
            try
            {
                var service = locationService();
                List<Location> result = service.List();
                if (result != null)
                {
                    
                    List<LocationDTO> listLocationDto = new List<LocationDTO>();
                    foreach (Location Item in result)
                    {
                        LocationDTO LocationDto = new LocationDTO();
                        LocationDto.locationId = Item.locationId;
                        LocationDto.locationName = Item.locationName;
                        LocationDto.locationOpenTime = Item.locationOpenTime.ToString();
                        LocationDto.locationCloseTime = Item.locationCloseTime.ToString();
                        listLocationDto.Add(LocationDto);
                    }
                    var json = JsonConvert.SerializeObject(listLocationDto);
                    return Ok(json);
                }
                else {
                    return StatusCode(204, "No Content");
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
            
        }

        // GET api/<ProductoController>/5
        /// <summary>
        /// Get one Location by Id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /location/{id}
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>A Locations identified by the input id</returns>
        /// <response code="200">Returns the Location identified by the Id</response>
        /// <response code="204">If the Id not exist in the DB</response>      
        /// <response code="500">If exist any kind of error</response>      
        [EnableCors("AllowOrigin")]  
        [HttpGet("{id}")]
        public ActionResult<Location> Get(Guid id)
        {
            try
            {
                var service = locationService();
                Location result = service.SelectById(id);
                if (result != null)
                {
                    LocationDTO LocationDto = new LocationDTO();
                    LocationDto.locationId = result.locationId;
                    LocationDto.locationName = result.locationName;
                    LocationDto.locationOpenTime = result.locationOpenTime.ToString();
                    LocationDto.locationCloseTime = result.locationCloseTime.ToString();
                    var json = JsonConvert.SerializeObject(LocationDto);
                    return Ok(json);
                }
                else {
                    return StatusCode(204, "No Content");
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
            
        }

        // POST api/<ProductoController>
        /// <summary>
        /// Get Locations by Time Range.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /location
        ///     {
        ///         "locationOpenTime":"10:00",
        ///         "locationCloseTime":"13:00"
        ///     }
        ///
        /// </remarks>
        /// <returns>A list of Locations that are available between the given OpenTime and CloseTime</returns>
        /// <response code="200">Returns the list of locations that are available in the range of time</response>
        /// <response code="400">If the user make a bad request</response>      
        /// <response code="204">If not exist any Location available in the input range</response>      
        /// <response code="500">If exist any kind of error</response>         
        [EnableCors("AllowOrigin")]  
        [HttpPost]
        public ActionResult<List<Location>> Post([FromBody] LocationDTO locationDTO)
        {
            if (string.IsNullOrEmpty(locationDTO.locationOpenTime) || string.IsNullOrEmpty(locationDTO.locationCloseTime)) {
                return StatusCode(400, "Bad user Request");
            }
            try
            {
                var service = locationService();
                List<Location> result = service.SeleccionarByTimeRange(_locationDTOConverter.DtoToLocation(locationDTO));
                if (result != null)
                {
                    
                    List<LocationDTO> listLocationDto = new List<LocationDTO>();
                    foreach (Location Item in result)
                    {
                        LocationDTO foundedLocationDto = new LocationDTO();
                        foundedLocationDto.locationId = Item.locationId;
                        foundedLocationDto.locationName = Item.locationName;
                        foundedLocationDto.locationOpenTime = Item.locationOpenTime.ToString();
                        foundedLocationDto.locationCloseTime = Item.locationCloseTime.ToString();
                        listLocationDto.Add(foundedLocationDto);
                    }
                    var json = JsonConvert.SerializeObject(listLocationDto);
                    return Ok(json);
                }
                else {
                    return StatusCode(204, "No Content");
                }
                
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal Server Error");
            }
            
        }
        // POST api/<ProductoController>/create
        /// <summary>
        /// Add Location.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /location
        ///     {
        ///         "name":"Nombre Localizacion",
        ///         "locationOpenTime":"10:00",
        ///         "locationCloseTime":"13:00"
        ///     }
        ///
        /// </remarks>
        /// <returns>A list of Locations that are available between the given OpenTime and CloseTime</returns>
        /// <response code="200">Returns the created location</response>
        /// <response code="400">If the user make a bad request</response>      
        /// <response code="500">If exist any kind of error</response>         
        [EnableCors("AllowOrigin")]
        [HttpPost]
        [Route("create")]
        public ActionResult<LocationDTO> PostCreate([FromBody] LocationDTO locationDTO)
        {

            if (string.IsNullOrEmpty(locationDTO.locationOpenTime) || string.IsNullOrEmpty(locationDTO.locationCloseTime) || string.IsNullOrEmpty(locationDTO.locationName))
            {
                return StatusCode(400, "Bad user Request");
            }


            if (string.IsNullOrEmpty(locationDTO.locationOpenTime))
            {
                return StatusCode(400, "Bad user Request");
            }
            try
            {
                var service = locationService();
                Location result = service.Add(_locationDTOConverter.DtoToLocation(locationDTO));
                LocationDTO newLocationDto = new LocationDTO();
                newLocationDto.locationId = result.locationId;
                newLocationDto.locationName = result.locationName;
                newLocationDto.locationOpenTime = result.locationOpenTime.ToString();
                newLocationDto.locationCloseTime = result.locationCloseTime.ToString();
                var json = JsonConvert.SerializeObject(newLocationDto);
                return Ok(json);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal Server Error");
            }


        }
    }
}
