using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Filters;
using ASM.Interfaces;
using ASM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers
{    
    public class CustomerController : Controller
    {
        private ICustomerSvc _customerSvc;
        public CustomerController(ICustomerSvc customerSvc)
        {
            _customerSvc = customerSvc;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_customerSvc.GetCustomerAll());
        }

        public IActionResult FindCustomerAll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindCustomerAll(string fullName)
        {
            if (fullName != null && fullName != "")
            {
                return View(_customerSvc.FindCustomerAll(fullName));
            }
            return RedirectToAction("Index");
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = null;
            customer = _customerSvc.GetCustomer(id);
            if (customer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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

        // GET: CustomerController/Edit/5
        [AuthenticationFilterAttribute_Cus]
        public ActionResult Edit(int id)
        {
            Customer customer = null;
            customer = _customerSvc.GetCustomer(id);
            if (customer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [AuthenticationFilterAttribute_Cus]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                _customerSvc.EditCustomer(id, customer);
                return RedirectToAction(nameof(Index),new { id=customer.CustomerID});
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
