using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
   public  interface IInventoryDL
    {
        Inventory AddInventory(Inventory L);
        List<Inventory> GetAllInventories();
        List<Inventory> GetInventoriesByLocation(int locationID);
        List<Inventory> GetInventoriesByCustomer(int customerID);
        ///Location FindLocationByName(string locationName);
    }
}
