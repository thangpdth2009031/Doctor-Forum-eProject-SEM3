using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Models;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class PostsController : Controller
    {
        DateTime dateTimeNow = DateTime.Now;
        private DoctorForumDbContext db = new DoctorForumDbContext();
        // GET: Admin/PostAdmin
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Account).Include(p => p.Specialization).Where(p=>p.Status == true);
            return View(posts.ToList());
        }
        public PartialViewResult NewestPost()
        {
            var post = db.Posts.OrderByDescending(p => p.Id).FirstOrDefault();
            return PartialView(post);
        }
        public PartialViewResult TypePost()
        {
            var post = db.Posts.Where(x=>x.Type == 2).OrderByDescending(p=>p.Id).ToList();
            return PartialView(post);
        }
        public PartialViewResult TypeKnowledge()
        {
            var post = db.Posts.Where(x => x.Type == 3).OrderByDescending(p => p.Id).FirstOrDefault();
            return PartialView(post);
        }

        // GET: Admin/PostAdmin/Details/5
        public ActionResult Details(int? id)
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
        

        // GET: Admin/PostAdmin/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar");
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name");
            return View();
        }

        // POST: Admin/PostAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                var account = (Account)Session[UserSession.USER_SESSION];
                post.AccountId = account.Id;
                post.Status = true;
                post.CreatedAt = DateTime.Parse(dateTimeNow.ToString("ddd, dd MMMM yyyy"));
                post.UpdatedAt = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Posts", "PersonalPage");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar", post.AccountId);
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", post.SpecializationId);
            return View(post);
        }

        // GET: Admin/PostAdmin/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar", post.AccountId);
            /*ViewBag.SpecializationId = new SelectList(Accountsdb.Specializations, "Id", "Name", post.SpecializationId);*/
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", post.SpecializationId);
            return View(post);
        }

        // POST: Admin/PostAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                var account = (Account)Session[UserSession.USER_SESSION];
                post.AccountId = account.Id;
                post.Status = true;
                post.UpdatedAt = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar", post.AccountId);
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", post.SpecializationId);
            return View(post);
        }

        // GET: Admin/PostAdmin/Delete/5
        public ActionResult Delete(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Post post)
        {
            if (ModelState.IsValid)
            {
                var account = (Account)Session[UserSession.USER_SESSION];
                post.AccountId = account.Id;
                if (account == null)
                {
                    return RedirectToAction("Login", "UserAccount");
                }
                else
                {
                    post.Status = false;
                    post.UpdatedAt = DateTime.Now;
                    db.Entry(post).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar", post.AccountId);
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", post.SpecializationId);
            return View(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult PostDetail()
        {
            return View();
        }

        public PartialViewResult Comment(int? id)
        {
            var comments = db.Replies.Where(x => x.PostId == id && x.Status == true);
            return PartialView(comments.ToList());
        }
        public PartialViewResult PostComment()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult PostComment(Reply reply)
        {
            if (ModelState.IsValid)
            {
                var account = (Account)Session[UserSession.USER_SESSION];
                reply.AccountId = account.Id;
                reply.Status = true;
                /*reply.Post = */
                /*reply.CreatedAt = DateTime.Parse(dateTimeNow.ToString("ddd, dd MMMM yyyy"));*/
                reply.CreatedAt = DateTime.Parse(dateTimeNow.ToString("ddd, dd MMMM yyyy"));
                reply.UpdatedAt = DateTime.Now;
                db.Replies.Add(reply);
                db.SaveChanges();
                return View(reply);
            }          
            return View(reply);
        }
    }
}
