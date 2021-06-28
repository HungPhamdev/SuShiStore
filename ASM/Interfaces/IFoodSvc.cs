using ASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interfaces
{
    public interface IFoodSvc
    {
        List<Food> GetFoodAll();
        List<Food> GetFoodAll_Foods();
        List<Food> GetFoodAll_Combos();
        List<Food> GetFoodAll_Waters();
        List<Food> FindFoodAll(string nameFood);
        Food GetFood(int id);
        int AddFood(Food monAn);
        int EditFood(int id, Food monAn);
    }
}
