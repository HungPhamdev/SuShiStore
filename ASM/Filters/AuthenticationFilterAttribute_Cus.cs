using ASM.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;


namespace ASM.Filters
{
    public class AuthenticationFilterAttribute_Cus : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //The action filter logic.
            Controller controller = filterContext.Controller as Controller;
            var session = filterContext.HttpContext.Session;
            string kH_Email = filterContext.HttpContext.Session.GetString(SessionKey.Customer.Cus_Email);
            var sessionStatus = ((kH_Email != null && kH_Email != "") ? true : false);
            if (controller != null)
            {
                if (session == null || !sessionStatus)
                {
                    filterContext.Result = new RedirectToRouteResult(
                                new RouteValueDictionary {
                                    {"controller", "Home" },
                                    {"action", "Login" }
                                });
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
