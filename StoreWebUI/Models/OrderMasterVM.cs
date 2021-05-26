using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;
namespace StoreWebUI.Models
{
    public class OrderMasterVM
    {
        public int Id { get; set; }
        Product product1 { get; set; }

        Product product2 { get; set; }
        public double Price { get; set; }
        public int Quantity1 { get; set; }

        public int Quantity2 { get; set; }

    }
}
