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
        public int qty1 { get; set; }
        public int qty2 { get; set; }
        public int qty3 { get; set; }
        public int pr1 { get; set; }
        public int pr2 { get; set; }
        public int pr3 { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string Name { get; set; }
        public IEnumerable<Customer> customers { set; get; }
        public IEnumerable<Location> Locations { set; get; }
        public IEnumerable<Product> products { set; get; }
        public List<Item> Items { get; set; }

        public override string ToString()
        {
            return $" Name:{Name} CustomerId {CustomerId} LocationId {LocationId}";
        }
    }
}
