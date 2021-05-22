using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IProductBL
    {
            Product AddProduct(Product p);
            List<Product> GetAllProducts();
            Product FindProductByName(string name);
    }
}