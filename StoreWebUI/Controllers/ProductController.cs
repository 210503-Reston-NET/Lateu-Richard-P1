using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModels;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Controllers
{
    public class ProductController : Controller
    {
       
        private IProductBL _productBL;
        private ILocationBL _locationBL;
        public ProductController(IProductBL ipbl, ILocationBL locationBL)
        {
            this._productBL = ipbl;
            this._locationBL = locationBL;

        }
        // GET: ProductController
        public ActionResult Index()
        {
            Console.WriteLine("--------------");
            Console.WriteLine(_productBL.GetAllProducts().Count);
            return View(_productBL.GetAllProducts().Select(p=>new ProductVM(p)).ToList());
           
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM pvm)
        {
            try
            {
                _productBL.AddProduct(new Product {
                    Id=pvm.Id,
                    Name=pvm.Name,
                    Price=pvm.Price,
                    Barcode=pvm.Barcode,
                    AvailableStock=pvm.AvailableStock,

    });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
