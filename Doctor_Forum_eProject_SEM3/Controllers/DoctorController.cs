using Doctor_Forum_eProject_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class DoctorController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListDoctor()
        {
            var listDoctor = db.Accounts.Where(x => x.Status == true).ToList();
            return View(listDoctor);
        }

    }
}