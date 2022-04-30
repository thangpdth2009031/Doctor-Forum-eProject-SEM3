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
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Dao;
using Doctor_Forum_eProject_SEM3.Models;

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class PostAdminController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();
        Post post = new Post();
        // GET: Admin/PostAdmin
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.AccountId).Include(p => p.Specialization);
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
                var account = (Account)Session[UserSession.USER_SESSION];
                post.AccountId = account.Id;
                post.Status = true;
                post.CreatedAt = DateTime.Now;
                post.UpdatedAt = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
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
                post.Status = false;
                post.UpdatedAt = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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

        public bool SaveImageToServer()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase file = files[0];
                string _apiKey = ConfigurationManager.AppSettings["CloudinaryAPIKey"];
                string _apiSecret = ConfigurationManager.AppSettings["CloudinarySecretKey"];
                string _cloud = ConfigurationManager.AppSettings["CloudinaryAccount"];
                string uploadedImageUrl = string.Empty;
                string fname = string.Empty;
                var myAccount = new CloudinaryDotNet.Account { ApiKey = _apiKey, ApiSecret = _apiSecret, Cloud = _cloud };
                Cloudinary _cloudinary = new Cloudinary(myAccount);
                // Checking for Internet Explorer  
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = Regex.Replace(file.FileName.Trim(), @"[^0-9a-zA-Z.]+", "_");
                }
                using (Image img = Image.FromStream(file.InputStream))
                {
                    int imageHeight = 0;
                    int imageWidth = 0;
                    if (img.Height > 320)
                    {
                        var ratio = (double)img.Height / 320;
                        imageHeight = (int)(img.Height / ratio);
                        imageWidth = (int)(img.Width / ratio);
                    }
                    else
                    {
                        imageHeight = img.Height;
                        imageWidth = img.Width;
                    }
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, file.InputStream),
                        Folder = "MyImages",
                        Transformation = new Transformation().Width(imageWidth).Height(imageHeight).Crop("thumb").Gravity("face")
                    };
                    var uploadResult = _cloudinary.UploadLarge(uploadParams);
                    uploadedImageUrl = uploadResult?.SecureUri?.AbsoluteUri;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
