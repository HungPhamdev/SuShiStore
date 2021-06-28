using ASM.Constants;
using ASM.Models;
using ASM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interfaces
{
    public interface IUserSvc
    {
        List<User> GetUserAll();
        User GetUser(int id);
        List<User> FindUserAll(string fullName);
        int AddUser(User user);
        int EditUser(int id, User user);
        public User Login(ViewLogin viewLogin);
    }
}
