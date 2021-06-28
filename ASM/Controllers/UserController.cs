using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASM.Filters;
using ASM.Interfaces;
using ASM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers
{
    [AuthentioncationFilterAtribute]
    public class UserController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IUserSvc _userSvc;
        private IUploadHelper _uploadHelper;
        public UserController(IWebHostEnvironment webHostEnvironment, IUserSvc userSvc, IUploadHelper uploadHelper)
        {
            _webHostEnvironment = webHostEnvironment;
            _userSvc = userSvc;
            _uploadHelper = uploadHelper;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(_userSvc.GetUserAll());
        }

        public IActionResult FindUserAll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindUserAll(string fullName)
        {
            if (fullName != null && fullName != "")
            {
                return View(_userSvc.FindUserAll(fullName));
            }
            return RedirectToAction("Index");
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            // Cách 1
            /*User user = null;
            user = _userSvc.getUser(id);
            if (user == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(user);*/

            // Cách 2
            return View(_userSvc.GetUser(id));
        }
        public ActionResult Details1(int id)
        {
            // Cách 1
            /*User user = null;
            user = _userSvc.getUser(id);
            if (user == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(user);*/

            // Cách 2
            return View(_userSvc.GetUser(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (user.ImageFile != null)
                {
                    if (user.ImageFile.Length > 0)
                    {
                        string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        _uploadHelper.UploadImage(user.ImageFile, rootPath, "User");
                        user.Image = user.ImageFile.FileName;
                    }
                }
                _userSvc.AddUser(user);
                return RedirectToAction(nameof(Details), new { id = user.UserID});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {// Cách 1
            /*User user = null;
            user = _userSvc.getUser(id);
            if (user == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(user);*/

            // Cách 2
            return View(_userSvc.GetUser(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            string subFolder = "User";
            try
            {
                if (ModelState.IsValid)
                {
                    if (user.ImageFile != null)
                    {
                        if (user.ImageFile.Length > 0)
                        {
                            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                            //_uploadHelper.RemoveImage(rootPath + @"\food\" + food.Image); Xóa hình
                            _uploadHelper.UploadImage(user.ImageFile, rootPath, subFolder);
                            user.Image = user.ImageFile.FileName;
                        }
                    }
                }
                _userSvc.EditUser(id, user);
                    return RedirectToAction(nameof(Details), new { id = user.UserID });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
            //return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
