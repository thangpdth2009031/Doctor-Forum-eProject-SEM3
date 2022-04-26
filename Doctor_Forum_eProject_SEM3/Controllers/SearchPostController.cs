using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class SearchPostController : Controller
    {
        // GET: SearchPost
        public ActionResult Index()
        {
            return View();
        }// GET: SearchPost
        public PartialViewResult Search()
        {
            return PartialView();
        }
    }
}