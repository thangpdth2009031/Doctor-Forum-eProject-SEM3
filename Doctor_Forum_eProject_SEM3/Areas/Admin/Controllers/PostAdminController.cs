using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Models;

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class PostAdminController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();

        // GET: Admin/PostAdmin
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Account).Include(p => p.Specialization);
            return View(posts.ToList());
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
           /* ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar");*/
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name");
            return View();
        }

        // POST: Admin/PostAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Type,SpecializationId,Image,AccountId,Tag,Status,CreatedAt,UpdatedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
                var account = (Account)Session[UserSession.USER_SESSION];
                Debug.WriteLine(account);
                post.AccountId = account.Id;
                post.Status = true;
                post.CreatedAt = DateTime.Now;
                post.UpdatedAt = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
/*
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar", post.AccountId);*/
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
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", post.SpecializationId);
            return View(post);
        }

        // POST: Admin/PostAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Type,SpecializationId,Image,AccountId,Tag,Status,CreatedAt,UpdatedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
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

        // POST: Admin/PostAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
