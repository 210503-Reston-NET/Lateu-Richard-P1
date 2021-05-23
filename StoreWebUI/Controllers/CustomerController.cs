using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBL;
using StoreWebUI.Models;
using StoreModels;

namespace StoreWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _customerBL;
        public CustomerController(ICustomerBL customerBL)
        {
            this._customerBL = customerBL;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_customerBL.GetAllCustomers().Select(
                customer=>new CustomerVM(customer)).ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerVM customerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerBL.AddCustomer(new Customer
                    {
                        Name = customerVM.Name,
                        Email = customerVM.Email,
                        Phone = customerVM.Phone,
                        Address = customerVM.Address,
                    });
                    return RedirectToAction(nameof(Index));
                }
                else { return View(); }
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new CustomerVM(_customerBL.FindCustomerById(id)));
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            //return View();
           
            return View(new CustomerVM(_customerBL.FindCustomerById(id)));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _customerBL.DeleteCustomer(_customerBL.FindCustomerById(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
