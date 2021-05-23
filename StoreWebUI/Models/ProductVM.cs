using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Barcode { get; set; }
        public int AvailableStock { get; set; }
        public ProductVM(){ }
        public ProductVM(Product p) {
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            Barcode = p.Barcode;
            AvailableStock = p.AvailableStock;
        
        }



    }
}
