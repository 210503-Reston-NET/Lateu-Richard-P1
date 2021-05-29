using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;
namespace StoreWebUI.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int Qty1 { get; set; }
        public int Qty2 { get; set; }
        public int Price1 { get; set; }
        public int Price2 { get; set; }
        public int ProductId1 { get; set; }
        public int ProductId2 { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string Name { get; set; }
        public virtual Customer Customer { get; set; }
        public OrderVM() { }
        public OrderVM(Order order) {
            this.Id = order.Id;
            this.Name = order.Name;
            this.OrderDate = order.OrderDate;
            this.CustomerId = order.CustomerId;
            this.LocationId = order.LocationId;
            this.OrderTotal = order.OrderTotal;
        }
        public IEnumerable<Customer> customers { set; get; }
        public IEnumerable<Location> Locations { set; get; }
        public IEnumerable<Product> products { set; get; }
        public List<Item> Items { get; set; }

        public override string ToString()
        {
            return $" Name:{Name} CustomerId {CustomerId} LocationId {LocationId} Product1:{ProductId1} Product2:{ProductId2}";
        }
    }
}
