using System;
using StoreModels;
using System.Collections.Generic;
using System.Linq;
namespace StoreDL
{
    public interface IProductDL
    {
         
           Product AddProduct(Product p);
            List<Product> GetAllProducts();
            Product FindProductByName(string name);
            Product FindProductById(int id);

    }
}