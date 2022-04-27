using Doctor_Forum_eProject_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class SearchDoctorController : Controller
    {
        // GET: SearchDoctor
        private DoctorForumDbContext db = new DoctorForumDbContext();
        public ActionResult Index()
        {
            return View();
        }// GET: SearchDoctor
        public PartialViewResult SearchDoctor()
        {
            return PartialView();
        }
       /* [HttpPost]*/
        public ActionResult Search(string keyword)
        {
            var doctors = db.Accounts.Where(s => s.FullName.Contains(keyword));
            return View(doctors.ToList());
        }
    }
}