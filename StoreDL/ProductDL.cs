using System;
using Model = StoreModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace StoreDL
{
    public class ProductDL : IProductDL
    {
        private StoreDBContext _context;
        public ProductDL()
        {
        }

        public ProductDL(StoreDBContext context)
        {
            this._context = context;
        }

        public Model.Product AddProduct(Model.Product product)
        {
            _context.Products.Add(
             product
          );

            _context.SaveChanges();
            return product;
        }

        public List<Model.Product> GetAllProducts()
        {

            return _context.Products.Select(
                  product => new Model.Product(product.Name, product.Barcode, product.Price, product.AvailableStock)
              ).ToList();

        }

        public Model.Product FindProductByName(string name)
        {
            Model.Product response = _context.Products.FirstOrDefault(product => product.Name == name);
            if (response == null) return null;
            return new Model.Product(response.Id, response.Name, response.Price,  response.Barcode,response.AvailableStock);

        }
    }
}