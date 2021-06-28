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
    public class FoodController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IFoodSvc _foodSvc;
        private IUploadHelper _uploadHelper;
        public FoodController(IWebHostEnvironment webHostEnvironment, IFoodSvc foodSvc, IUploadHelper uploadHelper)
        {
            _webHostEnvironment = webHostEnvironment;
            _foodSvc = foodSvc;
            _uploadHelper = uploadHelper;
        }

        // GET: FoodController
        public ActionResult Index()
        {
            return View(_foodSvc.GetFoodAll());
        }

        public IActionResult FindFoodAll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindFoodAll(string nameFood)
        {
            if (nameFood != null && nameFood != "")
            {
                return View(_foodSvc.FindFoodAll(nameFood));
            }
            return RedirectToAction("Index");
        }

        // GET: FoodController/Details/5
        public ActionResult Details(int id)
        {
            // Kiểm tra nếu food rỗng trả về view Index
            /*Food food = null;
            food = _foodSvc.getFood(id);
            if (food == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(food);*/

            // Khỏi kiểm tra có hay không cũng xuất
            return View(_foodSvc.GetFood(id));
        }

        // GET: FoodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Food food)
        {
            try
            {
                if (food.ImageFile != null)
                {
                    if (food.ImageFile.Length > 0)
                    {
                        string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        _uploadHelper.UploadImage(food.ImageFile, rootPath, "Food");
                        food.Image = food.ImageFile.FileName;
                    }
                }
                _foodSvc.AddFood(food);
                return RedirectToAction(nameof(Details), new { id = food.FoodID });               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: FoodController/Edit/5
        public ActionResult Edit(int id)
        {
            // Kiểm tra nếu food rỗng trả về view Index
            /*Food food = null;
            food = _foodSvc.getFood(id);
            if (food == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(food);*/

            // Khỏi kiểm tra có hay không cũng xuất
            return View(_foodSvc.GetFood(id));
        }

        // POST: FoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Food food)
        {
            string subFolder = "Food";
            try
            {
                if (ModelState.IsValid)
                {
                    if (food.ImageFile != null)
                    {
                        if (food.ImageFile.Length > 0)
                        {
                            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                            //_uploadHelper.RemoveImage(rootPath + @"\food\" + food.Image); Xóa hình
                            _uploadHelper.UploadImage(food.ImageFile, rootPath, subFolder);
                            food.Image = food.ImageFile.FileName;
                        }
                    }
                }
                _foodSvc.EditFood(id, food);
                return RedirectToAction(nameof(Details), new { id = food.FoodID });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            return RedirectToAction("Index");
            //return RedirectToAction(nameof(Index));
        }

        // GET: FoodController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodController/Delete/5
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
