﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Doctor_Forum_eProject_SEM3.Dao;
using Doctor_Forum_eProject_SEM3.Models;
using System.Configuration;

using CloudinaryDotNet.Actions;
using System.Text.RegularExpressions;
using System.Drawing;
using CloudinaryDotNet;
using Account = Doctor_Forum_eProject_SEM3.Models.Account;

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class AccountsManageController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();

        // GET: Admin/AccountsManage
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Specialization);
            return View(accounts.ToList());
        }

        // GET: Admin/AccountsManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/AccountsManage/Create
        public ActionResult Create()
        {
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name");
            return View();
        }

        // POST: Admin/AccountsManage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {                 
                account.CreatedAt = DateTime.Now;                
                account.UpdatedAt = DateTime.Now;                
                account.Status = true;                
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", account.SpecializationId);
            return View(account);
        }
        [HttpPost]
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
        // GET: Admin/AccountsManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", account.SpecializationId);
            return View(account);
        }

        // POST: Admin/AccountsManage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,Avatar,UserName,Password,FullName,AddressDetail,DistrictId,ProvinceId,CreatedAt,UpdatedAt,Status,SpecializationId")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", account.SpecializationId);
            return View(account);
        }

        // GET: Admin/AccountsManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/AccountsManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
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
                var todo = db.Accounts.Find(TaskIds[i]);
                todo.Status = false;
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
            /*[HasCredential(RoleID = "EDIT_USER")]*/
            public JsonResult ChangeStatus(long id)
            {
                var result = new UserDao().ChangeStatus(id);
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
