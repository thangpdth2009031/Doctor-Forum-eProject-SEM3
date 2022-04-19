using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult BlogDetails()
        {
            return View();
        }
        public ActionResult AccountProfile()
        {
            return View();
        }
    }

}