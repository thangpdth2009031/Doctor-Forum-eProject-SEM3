using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Doctor_Forum_eProject_SEM3.Models;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class BasesController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (Account)Session[Common.UserSession.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "UserAccount", action = "Login" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}