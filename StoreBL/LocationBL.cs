using StoreModels;
using StoreDL;
using System.Collections.Generic;
namespace StoreBL
{
    public class LocationBL : ILocationBL
    {
        private ILocationDL _locationDL;
        public LocationBL()
        {
        }
         public LocationBL(ILocationDL locationDL)
        {
            this._locationDL=locationDL;
        }

        public Location AddLocation(Location location){

            return _locationDL.AddLocation(location);
        }

        public  List<Location> GetAllLocations(){
           return _locationDL.GetAllLocations();
          }

          public   Location FindLocationByName(string location){
                 return _locationDL.FindLocationByName(location);
             }


       public  List<Order> ViewLocationOrders(string locationName){
            return _locationDL.ViewLocationOrders(locationName);
        }

        public void ViewLocationInventory(string name){
            
        }
    }
}