using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;
namespace StoreWebUI.Models
{
    public class InventoryVM
    {
        public InventoryVM() { }
        public InventoryVM(Inventory iv) {
            this.Id = iv.Id;
            this.LocationId = iv.LocationId;
            this.ProductId = iv.ProductId;
            this.Quantity = iv.Quantity;
            this.OrderDate = iv.OrderDate;
                }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { set; get; }
        public DateTime OrderDate { get; set; }
        public string Inventorytype { get; set; }
    }
}
