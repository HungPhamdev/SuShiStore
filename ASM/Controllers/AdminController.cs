using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Constants;
using ASM.Interfaces;
using ASM.Models;
using ASM.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASM.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IUserSvc _userSvc;

        public AdminController(IWebHostEnvironment webHostEnvironment, IUserSvc userSvc)
        {
            _webHostEnvironment = webHostEnvironment;
            _userSvc = userSvc;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController
        public IActionResult Login(string returnUrl)
        {
            string userName = HttpContext.Session.GetString(SessionKey.User.UserName);
            if (userName != null && userName != "")// Đã có session
            {
                return RedirectToAction("Index", "Home");
            }
            #region Hiển thị Login
            ViewLogin login = new ViewLogin();
            login.ReturnUrl = returnUrl;
            return View(login);
            #endregion
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(ViewLogin viewLogin)
        {
            if (ModelState.IsValid)
            {
                User user = _userSvc.Login(viewLogin);
                if (user != null)
                {
                    HttpContext.Session.SetString(SessionKey.User.UserName, user.UserName);
                    HttpContext.Session.SetString(SessionKey.User.FullName, user.FullName);
                    HttpContext.Session.SetString(SessionKey.User.UserContext, JsonConvert.SerializeObject(user));

                    return RedirectToAction(nameof(Index), "Admin");
                }                                
            }
            return View(viewLogin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKey.User.UserName);
            HttpContext.Session.Remove(SessionKey.User.FullName);
            HttpContext.Session.Remove(SessionKey.User.UserContext);
            return RedirectToAction(nameof(Index), "Admin");
        }

        /*// GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
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

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
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
