using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModels;


namespace StoreDL
{
    public class InventoryDL : IInventoryDL
    {
        private StoreDBContext _context;
        public InventoryDL(StoreDBContext e) { this._context = e; }
        public Inventory AddInventory(Inventory L)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventoriesByCustomer(int customerID)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventoriesByLocation(int locationID)
        {
            return _context.Inventories.Where(
                    inventory => inventory.LocationId == locationID
                ).Select(
                    inventory => inventory
                ).ToList();
        }
        public List<Inventory> GetAllInventories()
        {

            return _context.Inventories.Select(
                  inventory => inventory
              ).ToList();

        }
       
    }
}
