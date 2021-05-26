using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBL;
using StoreModels;
using StoreWebUI.Models;

namespace StoreWebUI.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryBL inventoryBL;
        // GET: InventoryController

        public InventoryController(IInventoryBL e) { this.inventoryBL = e; }
        public ActionResult Index(int locationID)
        {
            //List<Inventory> inventories = new List<Inventory>();
            List<InventoryVM> inventoriesVM = new List<InventoryVM>();

            if (locationID != 0)
            {
                inventoriesVM = inventoryBL.GetInventoriesByLocation(locationID).Select(
                    inventory => new InventoryVM(inventory)).ToList();
            }
            else
            {
                
                inventoriesVM = inventoryBL.GetAllInventories().Select(
                  inventory => new InventoryVM(inventory)).ToList();

            }
            return View(inventoriesVM);
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryController/Create
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

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryController/Edit/5
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

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
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
