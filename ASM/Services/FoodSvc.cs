using ASM.Interfaces;
using ASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Services
{
    public class FoodSvc : IFoodSvc
    {
        private DataContext _dataContext;
        public FoodSvc(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Food> GetFoodAll()
        {
            List<Food> foodList = new List<Food>();
            foodList = _dataContext.Foods.ToList();
            return foodList;
        }

        public List<Food> GetFoodAll_Foods()
        {
            List<Food> foods = new List<Food>();
            foods = _dataContext.Foods.Where(x=>x.Classify == Classify.Food).ToList();
            return foods;
        }

        public List<Food> GetFoodAll_Combos()
        {
            List<Food> combos = new List<Food>();
            combos = _dataContext.Foods.Where(x => x.Classify == Classify.Combo).ToList();
            return combos;
        }

        public List<Food> FindFoodAll(string nameFood)        
        {            
            return _dataContext.Foods.Where(f => f.Name.Contains(nameFood)).ToList();
        }

        public List<Food> GetFoodAll_Waters()
        {
            List<Food> waters = new List<Food>();
            waters = _dataContext.Foods.Where(x => x.Classify == Classify.Water).ToList();
            return waters;
        }

        public Food GetFood(int id)
        {
            Food food = null;
            food = _dataContext.Foods.Find(id);
            //monAn = _dataContext.MonAns.Where(x => x.MonAnID == id).FirstOrDefault();
            return food;
        }
        public int AddFood(Food food)
        {
            int ret = 0;
            try
            {
                _dataContext.Foods.Add(food);
                _dataContext.SaveChanges();
                ret = food.FoodID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = 0;
            }
            return ret;
        }
        public int EditFood(int id, Food food)
        {
            int ret = 0;
            try
            {
                // Cách 1: Sửa từng property
                /*MonAn _monAn = null;
                _monAn = _dataContext.MonAns.Find(id);
                _monAn.Name = monAn.Name;
                _monAn.Price = monAn.Price;
                _monAn.PhanLoai = monAn.PhanLoai;
                _monAn.Image = monAn.Image;
                _monAn.Des = monAn.Des;
                _monAn.Status = monAn.Status;
                _dataContext.MonAns.Update(_monAn);
                _dataContext.SaveChanges();*/
                // Cách 2: Sửa hết hoặc giữ nguyên vẫn được
                _dataContext.Foods.Update(food);
                _dataContext.SaveChanges();
                ret = food.FoodID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = 0;
            }
            return ret;
        }
    }
}
