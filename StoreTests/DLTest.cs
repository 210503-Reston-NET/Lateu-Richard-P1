using Microsoft.EntityFrameworkCore;
using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace StoreTests
{
   public class DLTest
    {
        private readonly DbContextOptions<StoreDBContext> options;

        public DLTest()
        {
            options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename=StoreTest.db").Options;
            Seed();
        }

        [Fact]
        public void GetAllLocationsShouldReturnAllLocations()
        {
            //putting in a test context/ connection to our test db
            using (var context = new StoreDBContext(options))
            {
                //Arrange
                ILocationDL _locationDL = new LocationDL(context);

                //Act
                var locations = _locationDL.GetAllLocations();

                //Assert
                Assert.Equal(2, locations.Count);
            }
        }

        //When testing operations that change the state of the db (i.e manipulate the data inside the db) 
        //make sure to check if the change has persisted even when accessing the db using a different context/connection
        //This means that you create another instance of your context when testing to check that the method has 
        //definitely affected the db.
        //What operations affect the state of the db? Create, Update, Delete
        [Fact]
        public void AddLocationShouldAddLocation()
        {
            using (var context = new StoreDBContext(options))
            {
                ILocationDL _locationDL = new LocationDL(context);
                //Act with a test context
                _locationDL.AddLocation
                (
                    new Location(3, "Dallas", "^9000 TX")
                );
            }
            //use a diff context to check if changes persist to db
            using (var assertContext = new StoreDBContext(options))
            {
                //Assert with a different context
                var result = assertContext.Locations.FirstOrDefault(locaton => locaton.Id == 3);
                Assert.NotNull(result);
                Assert.Equal("Dallas", result.Name);
            }
        }

        [Fact]
        public void FindExistingProductByNameShouldSucceed()
        {
            using (var context = new StoreDBContext(options))
            {
                IProductDL _productDL = new ProductDL(context);
                //Act with a test context
                


                Assert.NotNull(_productDL.FindProductByName("Break"));
            }
                 
            
        }
        private void Seed()
        {
            //This makes sure that the state of the db gets recreated everytime to maintain modularity of tests
            using (var context = new StoreDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Locations.AddRange
            (
                new Location
                {
                    Id = 1,
                    Name = "Smyrna",
                    Address = "980 GA",

                    Customers = new List<Customer>
                    {
                            new Customer
                            {
                                Id = 1,
                                Name = "Lateu",
                                Phone = "98560",
                                Email="todo@gmail.com",
                                Address="SM GA"
                            },
                            new Customer
                            {
                               Id = 2,
                                Name = "Lateu3",
                                Phone = "8963",
                                Email="todo3@gmail.com",
                                Address="HM GA"
                            }
                    }
                },
                new Location
                {
                    Id = 2,
                    Name = "Small ville",
                    Address = "690 small ville  TX ",
                  
                    Customers = new List<Customer>
                    {
                             new Customer
                            {
                                Id = 3,
                                Name = "Lateu6",
                                Phone = "8674849",
                                Email="todo4@gmail.com",
                                Address="SM GA 490"
                            },
                            new Customer
                            {
                               Id = 4,
                                Name = "Lateu4",
                                Phone = "476473",
                                Email="todo4@gmail.com",
                                Address="8904 HM GA"
                            }
                    }
                }
            );
            context.Products.AddRange
           (
               new Product
               {
                   Id = 1,
                   Name = "Break",
                   Barcode = "",
                   Price=50,
                   AvailableStock=90,
               });

             

                context.SaveChanges();
            context.ChangeTracker.Clear();
        }
   
   }
    
  }
    
}
