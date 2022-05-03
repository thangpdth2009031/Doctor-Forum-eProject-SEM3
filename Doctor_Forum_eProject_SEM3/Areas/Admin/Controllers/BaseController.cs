using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Models;

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin) Session[Common.UserSession.USER_SESSION];
            if (session == null || session.GroupId == "MEMBER")
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new {controller = "Login", action = "Login", Area = "Admin"}));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
