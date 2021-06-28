using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Constants;
using ASM.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers
{
    [AuthentioncationFilterAtribute]
    public abstract class BaseController : Controller
    {
        public BaseController() { }

        protected string GetUserName()
        {
            return HttpContext.Session.GetString(SessionKey.User.UserName);
        }
        protected string GetFullName()
        {
            return HttpContext.Session.GetString(SessionKey.User.FullName);
        }
        protected string GetCusEmail()
        {
            return HttpContext.Session.GetString(SessionKey.Customer.Cus_Email);
        }        
    }
}
