﻿using System;
using Model = StoreModels;
using System.Collections.Generic;
using System.Linq;
namespace StoreDL
{
    public class LocationDL : ILocationDL
    {


        private StoreDBContext _context;
        public LocationDL() { }
        public LocationDL(StoreDBContext context)
        {
            this._context = context;
        }

        public Model.Location AddLocation(Model.Location location)
        {
            _context.Locations.Add(
              new Model.Location
              {
                  Name = location.Name,
                  Address = location.Address,


              }
          );

            _context.SaveChanges();
            return location;
        }

        public List<Model.Location> GetAllLocations()
        {

            return _context.Locations.Select(
                  location => new Model.Location(location.Name, location.Address)
              ).ToList();

        }

        public Model.Location FindLocationByName(string name)
        {
            Model.Location response = _context.Locations.FirstOrDefault(location => location.Name == name);
            if (response == null) return null;
            return new Model.Location(response.Id, response.Name, response.Address);

        }

        public List<Model.Order> ViewLocationOrders(string locationName)
        {

            return _context.Orders.Where(
          order => order.LocationId == FindLocationByName(locationName).Id
          ).Select(
              order => new Model.Order
              {
                        /*  CustomerId = order.CustomerId,       
                          StoreId=order.StoreId,
                          OrderDate=order.OrderDate,
                          OrderTotal = order.OrderTotal,*/

              }
          ).ToList();
        }

        /* public  List<Model.Item>  ViewLocationInventory(string name){
          return _context.Items.Where(
            item => item.RestaurantId == GetRestaurant(restaurant).Id
            ).Select(
                review => new Model.Review
                {
                    Rating = review.Rating,
                    Description = review.Description
                }
            ).ToList();
         }*/
    }
}