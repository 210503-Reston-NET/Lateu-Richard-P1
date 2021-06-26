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
    public class OrderItemController : Controller
    {
        // GET: ItemController
        private IOrderBL _orderBL;
        private IProductBL _productBL;
        public OrderItemController(IOrderBL e, IProductBL x) { this._orderBL = e;this._productBL = x; }
        public ActionResult Index(int id)
        {
            Order o = _orderBL.FindOrderById(id);
            ViewBag.order = o;
            if (o != null){
                    ViewData.Add("OrderId", o.Name);
                    ViewData.Add("Status", o.Status);
                    ViewData.Add("Total", o.OrderTotal.ToString());
                
            }
              else
               {
                ViewData.Add("OrderId", "");
                ViewData.Add("Status ", "");
                ViewData.Add("Total($) ", 0);
            }


            List<OrderItem> items = _orderBL.DisplayOrderDetails(id);
            return View(items.Select(
                item=>new ItemVM(item)));
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemController/Create
        public ActionResult Create(int id )
        {
            var model = new ItemVM();
            model.OrderId = id;
            model.Products = _productBL.GetAllProducts().ToList();
            //List<Product> products =_productBL.GetAllProducts().ToList();

            return View(model);
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemVM itemVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _orderBL.AddItem(new OrderItem(itemVM.OrderId, itemVM.ProductId, itemVM.Quantity, itemVM.UnitPrice));
                    return RedirectToAction(nameof(Index), new { id = itemVM.OrderId });
                }
                return View();
               
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemController/Edit/5
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

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemController/Delete/5
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
