using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class PersonalPageController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();
        // GET: PersonalPage
        public ActionResult Posts()
        {            
            var account = (Account)Session[UserSession.USER_SESSION];
            if (account == null)
            {
                return RedirectToAction("Login", "AccountModels");
            } else
            {
                var post = db.Posts.Where((x => x.Status == (true) && x.AccountId == (account.Id))).ToList();                
                return View(post);
            }            
        }
    }
}