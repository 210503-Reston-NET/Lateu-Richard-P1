using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBL
{
   public  interface IInventoryBL
    {
        List<Inventory> GetInventoriesByLocation(int locationID);
        List<Inventory> GetAllInventories();
    }
}
