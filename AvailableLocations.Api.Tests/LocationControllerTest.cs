using AvailableLocations.Domain;
using AvailableLocations.Domain.Interfaces.Repositories;
using AvailableLocations.Infraestructure.API.Controllers;
using AvailableLocations.Infraestructure.API.Converters;
using AvailableLocations.Services.DTOs;
using AvailableLocations.Services.Interfaces;
using AvailableLocations.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace AvailableLocations.Api.Tests
{
    public class LocationControllerTest
    {
        private readonly LocationController _controller;
        private readonly IBaseService<Location, Guid> _service;
        private readonly IBaseRepository<Location, Guid> _repo;
        private readonly ILocationDTOConverter _LocationDtoConverter;

        public LocationControllerTest()
        {
            _service = new LocationService(_repo);
            _controller = new LocationController(_LocationDtoConverter);
        }

        /// <summary>
        /// Testing The services Required for The code Test.
        /// GetAll
        /// Post(GetByTimeRange)
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// I only created test for the needed endPoint.
        /// </remarks>

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.Get();
            var okResultParced = (OkObjectResult)okResult.Result;

            //Assert
            Assert.IsType<OkObjectResult>(okResultParced as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get();
            var okResultParced = (OkObjectResult)okResult.Result;

            var jsonObject = JsonConvert.DeserializeObject<List<LocationDTO>>(okResultParced.Value.ToString());
            // Assert
            var items = Assert.IsType<List<LocationDTO>>(jsonObject);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsFilteredItems()
        {
            // Act
            LocationDTO request = new LocationDTO() 
            {
                locationOpenTime = "10:00",
                locationCloseTime = "13:00"
        };
            var okResult = _controller.Post(request);
            var okResultParced = (OkObjectResult)okResult.Result;

            var jsonObject = JsonConvert.DeserializeObject<List<LocationDTO>>(okResultParced.Value.ToString());
            // Assert
            var items = Assert.IsType<List<LocationDTO>>(jsonObject);
            Assert.Equal(2, items.Count);
        }
    }
}
