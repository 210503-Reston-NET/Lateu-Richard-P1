using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDL;

namespace StoreBL
{
  public  class InventoryBL : IInventoryBL
    {
        private IInventoryDL _inventoryDL;

        public InventoryBL(IInventoryDL e)
        {
            this._inventoryDL = e;

        }
        public List<Inventory> GetInventoriesByLocation(int locationID)
        {
            return _inventoryDL.GetInventoriesByLocation(locationID);
        }

        public List<Inventory> GetAllInventories()
        {
            return _inventoryDL.GetAllInventories();
        }
    }
}
