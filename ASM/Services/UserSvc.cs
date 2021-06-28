using ASM.Constants;
using ASM.Interfaces;
using ASM.Models;
using ASM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Services
{
    public class UserSvc : IUserSvc
    {
        protected DataContext _dataContext;
        protected IEncodeHelper _encodeHelper;
        public UserSvc(DataContext dataContext, IEncodeHelper encodeHelper)
        {
            _dataContext = dataContext;
            _encodeHelper = encodeHelper;
        }
        public List<User> GetUserAll()
        {
            List<User> userList = new List<User>();
            userList = _dataContext.Users.ToList();
            return userList;
        }
        public User GetUser(int id)
        {
            User user = null;
            user = _dataContext.Users.Find(id);
            return user;
        }

        public List<User> FindUserAll(string fullName)
        {
            return _dataContext.Users.Where(f => f.FullName.Contains(fullName)).ToList();
        }

        public int AddUser(User user)
        {
            int ret = 0;
            try
            {                
                user.Password = _encodeHelper.Encode(user.Password);
                _dataContext.Add(user);
                _dataContext.SaveChanges();
                ret = user.UserID;                              
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = 0;
            }
            return ret;
        }
        public int EditUser(int id, User user) //edit has bug
        {
            int ret = 0;
            try
            {
                User _user = null;
                _user = _dataContext.Users.Find(id);
                _user.UserName = user.UserName;
                _user.FullName = user.FullName;
                _user.Title = user.Title;
                _user.DOB = user.DOB;
                _user.Email = user.Email;
                _user.Admin = user.Admin;
                _user.Locked = user.Locked;
                if (user.Password != null)
                {
                    user.Password = _encodeHelper.Encode(user.Password);
                    _user.Password = user.Password;
                }
                _dataContext.Update(_user);
                _dataContext.SaveChanges();
                ret = user.UserID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = 0;
            }
            return ret;
        }
        public User Login(ViewLogin viewLogin)
        {
            var u = _dataContext.Users.Where(
                p => p.UserName.Equals(viewLogin.UserName)
                && p.Password.Equals(_encodeHelper.Encode(viewLogin.Password))
                ).FirstOrDefault();
            return u;
        }
    }
}
