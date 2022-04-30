using Doctor_Forum_eProject_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class HomeController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();
        // GET: Admin/PostAdmin
        public ActionResult Index()
        {
            var posts = db.Posts.Where(x=>x.Status == true).ToList();
            return View(posts);
        }
        public PartialViewResult SearchDoctor()
        {
            ViewBag.Specialization = new SelectList(db.Specializations.Where(x => x.Status == true));
            return PartialView();
        }
        public ActionResult PostDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}