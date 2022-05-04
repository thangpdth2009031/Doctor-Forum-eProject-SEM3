using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Dao;
using Doctor_Forum_eProject_SEM3.Models;

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class PostAdminController : BaseController
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();
        Post post = new Post();
        // GET: Admin/PostAdmin
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Account).Include(p => p.Specialization);

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }


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
                var account = (UserLogin)Session[UserSession.USER_SESSION];
                if (account != null)
                {
                    post.AccountId = account.Id;
                    post.Status = true;
                    post.CreatedAt = DateTime.Now;
                    post.UpdatedAt = DateTime.Now;
                    db.Posts.Add(post);
                    db.SaveChanges();



                    TempData["result"] = "Thêm mới thành công";
                        return RedirectToAction("Index");
                    


                }
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
               var account = (UserLogin)Session[UserSession.USER_SESSION];

               if (account != null)
               {
                   post.AccountId = account.Id;
                   post.Status = true;
                   post.UpdatedAt = DateTime.Now;
                   db.Entry(post).State = EntityState.Modified;
                   db.SaveChanges();

                   TempData["result"] = "Sửa thành công";
                    return RedirectToAction("Index");
               }
               else
               {
                  
               }
                
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
                var account = (UserLogin)Session[UserSession.USER_SESSION];
                if (account != null)
                {
                    post.AccountId = account.Id;
                    post.Status = false;
                    post.UpdatedAt = DateTime.Now;
                    db.Entry(post).State = EntityState.Modified;
                    db.SaveChanges();


                    TempData["result"] = "Xóa thành công";
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar", post.AccountId);
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", post.SpecializationId);
            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAll(string[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                ModelState.AddModelError("", "No item selected to delete");
                return View();
            }
            List<int> TaskIds = ids.Select(x => Int32.Parse(x)).ToList();
            for (var i = 0; i < TaskIds.Count(); i++)
            {
                var todo = db.Posts.Find(TaskIds[i]);
                todo.Status = false;
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
            }

            TempData["result"] = "Xóa hết thành công";
            return RedirectToAction("Index");
        }

        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatusPost(id);
            return Json(new
            {
                status = result
            });
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
