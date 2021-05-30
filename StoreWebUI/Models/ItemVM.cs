using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace StoreWebUI.Models
{
    public class ItemVM
    {
        public int  Id{ get; set; }
    public double UnitPrice { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public ItemVM() { }
        public ItemVM(int orderid, List<Product> l) { this.OrderId = orderid; }
        public IEnumerable<Product> products { set; get; }

        public ItemVM(Item item) {
            this.Id = item.Id;
            this.ProductId = item.ProductId;
            this.Quantity = item.Quantity;
            this.UnitPrice = item.UnitPrice;
                
                }

        public override string ToString()
        {
            return $"Id:{Id} Product:{ProductId}";
        }
    }
}
