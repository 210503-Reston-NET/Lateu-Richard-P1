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

namespace StoreTests
{
    public class LocationBLTest
    {
        [Fact]
        public void GetAllLocationsShouldContainsElement()
        {
            //arrange
            var mockRepo = new Mock<ILocationDL>();
            mockRepo.Setup(x => x.GetAllLocations()).Returns(
                new List<Location>()
                {
                    new Location(5,"Colifornia ","890 CA "),
                    new Location(6,"Georgia ","897 GA "),
                     
                }
                ) ;
            var locationBl = new LocationBL(mockRepo.Object);

            //Act
            var res = locationBl.GetAllLocations();

            //Assert
            Assert.True(res.Count > 0);
        }
    }
}
