using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ILocationDL
    {
           Location AddLocation(Location L);
           List<Location> GetAllLocations();
           Location FindLocationByName(string locationName);

           List<Order> ViewLocationOrders(string name); 
         //  List<Item> ViewLocationInventory(string name); 
    }
}