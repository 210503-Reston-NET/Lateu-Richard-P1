using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
namespace StoreBL
{
    public class ProductBL : IProductBL
    {
        private IProductDL _productDL;
         private IOrderDL _orderDLAccess;
         private ILocationDL _locationDL;
        public ProductBL()
        {
        }
         public ProductBL(IProductDL pdl,IOrderDL iorderDL,ILocationDL locationDL)
        {
            this._productDL=pdl;
            this._orderDLAccess=iorderDL;
            this._locationDL=locationDL;
        }

       public Product AddProduct(Product p){
            Inventory inv=new Inventory();
            inv.LocationId = _locationDL.GetAllLocations()[0].Id;
            //inv.LocationId=_locationDL.FindLocationByName("California").Id;
            inv.Inventorytype="IN";
            inv.OrderDate=DateTime.Now;
            Product product= _productDL.AddProduct(p);
            try {
                inv.ProductId = _productDL.FindProductByName(p.Name).Id;
            }catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
    
            inv.Quantity=p.AvailableStock;
            
            //Console.WriteLine("invetory-------");
            _orderDLAccess.AddToInventory(inv);
            
            return product;
         
       }
           public List<Product> GetAllProducts(){
            return _productDL.GetAllProducts();
            //return new List<Product>();
           }
            public Product FindProductByName(string name){
            return _productDL.FindProductByName(name);
            }
    }
}