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
    public class OrderController : Controller
    {
        private ILocationBL _locationBL;
        private ICustomerBL _customerBL;
        private IProductBL _productBL;
        private IOrderBL _orderBL;
        public OrderController(ILocationBL l, ICustomerBL b, IProductBL p,IOrderBL e) { this._locationBL = l; this._customerBL = b;  this._productBL = p;this._orderBL = e; }
        // GET: OrderController
        public ActionResult Index()
           
        {
            List<OrderVM> l = new List<OrderVM>() { };

            return View(_orderBL.FindAllOrders().Select(order => new OrderVM(order)).ToList());
        }

        /// <summary>
        ///  return order for customer with given id
        /// </summary>
        /// <param name="cutomerID"></param>
        /// <returns></returns>
        public ActionResult CustomerOrders( )

        {
            int cutomerID = int.Parse(this.RouteData.Values["id"].ToString());
            List<OrderVM> orders = _customerBL.ViewOrderHistoryByCustomer(cutomerID).Select(order => new OrderVM(order)).ToList();
            System.Diagnostics.Debug.WriteLine("===============================");
            System.Diagnostics.Debug.WriteLine(orders.Count);
            return View(orders);
        }

        public ActionResult LocationOrders()

        {
            int LocationID = int.Parse(this.RouteData.Values["id"].ToString());
            List<OrderVM> orders = _locationBL.ViewLocationOrders(LocationID).Select(order => new OrderVM(order)).ToList();
            System.Diagnostics.Debug.WriteLine("============LocationOrders===================");
            System.Diagnostics.Debug.WriteLine(orders.Count);
            System.Diagnostics.Debug.WriteLine(LocationID.ToString());
            return View(orders);

        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            //ViewBag.Locations = _locationBL.GetAllLocations().ToList();       
            //ViewBag.customers = _customerBL.GetAllCustomers().ToList();
            // ViewBag.products = _productBL.GetAllProducts().ToList();
       
            string orderID = DateTime.Now.ToString().Substring(0, 17).Replace("/", "").Replace(":", "").Replace(" ", "");
            var model =new  OrderVM();
            ViewData.Add("orderID", orderID);
            model.Locations = _locationBL.GetAllLocations().ToList();
            model.Customers = _customerBL.GetAllCustomers().ToList();
            model.Products = _productBL.GetAllProducts().ToList();

            return View(model);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM collection)
        {
            try
            {
                List<Item> Items = new List<Item>();
                Item item1 = new Item();
                //Item item2 = new Item();
                double total = 0;
                item1.ProductId = collection.ProductId1;
                item1.Quantity = collection.Qty1;
                item1.UnitPrice = collection.Price1;
                total+= collection.Price1 * collection.Qty1; ;

              /*  item2.ProductId = collection.ProductId2;
                item2.Quantity = collection.Qty2;
                item2.UnitPrice = collection.Price2;
                total += collection.Price2* collection.Qty2;
               */

                Items.Add(item1);
                //Items.Add(item2);
                         
                //Items.Add(_productBL.)
                _orderBL.PlaceOrder(collection.Name,total,collection.CustomerId, collection.LocationId, Items);

                System.Diagnostics.Debug.WriteLine(collection.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
