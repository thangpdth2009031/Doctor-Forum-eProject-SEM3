using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Models;

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {

            var session = (Account)Session[Doctor_Forum_eProject_SEM3.Common.UserSession.USER_SESSION];

            if (session == null || session.GroupId == "MEMBER")
            {
                
                return RedirectToAction("Login", "Login");

                
            } 
            else
            {
                return View();
            }
        }
        
          public ActionResult Form()
        {
            return View();
        }
    }
}