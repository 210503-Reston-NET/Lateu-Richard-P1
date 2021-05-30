using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface ILocationBL
    {
     void ViewLocationInventory(string name); 
   Location AddLocation(Location location);
      List<Location> GetAllLocations();

        Location FindLocationByName(string locationName);

         List<Order> ViewLocationOrders(int id); 
    }
}