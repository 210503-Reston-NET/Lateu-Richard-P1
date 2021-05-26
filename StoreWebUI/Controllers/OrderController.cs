﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
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

        public OrderController(ILocationBL l, ICustomerBL b, IProductBL p) { this._locationBL = l; this._customerBL = b;  this._productBL = p; }
        // GET: OrderController
        public ActionResult Index()
           
        {
            List<OrderVM> l = new List<OrderVM>() { };
            return View(l);
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
            model.customers = _customerBL.GetAllCustomers().ToList();
            model.products = _productBL.GetAllProducts().ToList();

            return View(model);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
