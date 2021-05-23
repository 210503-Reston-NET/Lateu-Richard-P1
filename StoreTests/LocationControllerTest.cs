using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StoreModels;
using Xunit;
using StoreBL;
using StoreDL;
using StoreWebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using StoreWebUI.Models;

namespace StoreTests
{
   public class LocationControllerTest
    { 
        [Fact]
        public void LocationControllerIndexShouldReturnList()
        {
            //Arrange
            var mockBL = new Mock<ILocationBL>();
            mockBL.Setup(x => x.GetAllLocations()).Returns(
                new List<Location>()
                {
                    new Location(1, "Washington", "DC"),
                    new Location(2, "Hayward", "California")
                }
                );
            var controller = new LocationController(mockBL.Object);
            //Act
            var result = controller.Index();

            //Assert
            //Checktthe result type
            var viewResult = Assert.IsType<ViewResult>(result);
            //Check that the model of the viewResult is a list of location VMs
            var model = Assert.IsAssignableFrom<IEnumerable<LocationVM>>(viewResult.ViewData.Model);
            //Check that we're getting the same amount of restaurants that we're returning
            Assert.Equal(2, model.Count());
        }
    }
}
