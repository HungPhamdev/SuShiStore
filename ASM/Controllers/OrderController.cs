using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Interfaces;
using ASM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers
{
    public class OrderController : Controller
    {
        private IOrderSvc _orderSvc;
        public OrderController(IOrderSvc orderSvc)
        {
            _orderSvc = orderSvc;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View(_orderSvc.GetOrderAll());
        }

        public IActionResult FindOrderAll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindOrderAll(double totalMoney)
        {
            if (totalMoney > 0)
            {
                return View(_orderSvc.FindOrderAll(totalMoney));
            }
            return RedirectToAction("Index");
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View(_orderSvc.GetOrder(id));
        }

        /*// GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
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
        }*/

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var order = _orderSvc.GetOrder(id);
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                order.Customer = null;
                _orderSvc.EditOrder(id, order);
                return RedirectToAction(nameof(Details), new { id=order.OrderID});
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        /*// GET: OrderController/Delete/5
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
        }*/
    }
}
