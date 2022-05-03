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

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class ExperiencesController : BaseController
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();

        // GET: Admin/Experiences
        public ActionResult Index()
        {
            var experiences = db.Experiences.Include(e => e.Account);

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }



            return View(experiences.ToList());
        }

        // GET: Admin/Experiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        // GET: Admin/Experiences/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "UserName");
            return View();
        }

        // POST: Admin/Experiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountId,StartYear,EndYear,Description,Status,CreatedAt,UpdatedAt,Workplace,Position")] Experience experience)
        {
            if (ModelState.IsValid)
            {                
                experience.Status = true;            
                experience.UpdatedAt = DateTime.Now;
                db.Experiences.Add(experience);
                db.SaveChanges();
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index");              
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "UserName", experience.AccountId);
            return View(experience);
        }

        // GET: Admin/Experiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "UserName", experience.AccountId);
            return View(experience);
        }

        // POST: Admin/Experiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Experience experience)
        {
            if (ModelState.IsValid)
            {
                experience.UpdatedAt = DateTime.Now;
                db.Entry(experience).State = EntityState.Modified;
                db.SaveChanges();


                TempData["result"] = "Sửa thành công";
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "UserName", experience.AccountId);
            return View(experience);
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
                var todo = db.Experiences.Find(TaskIds[i]);
                todo.Status = false;
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/Experiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        // POST: Admin/Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experience experience = db.Experiences.Find(id);
            experience.Status = false;
            experience.UpdatedAt = DateTime.Now;
            db.Experiences.Remove(experience);
            db.SaveChanges();

            TempData["result"] = "Xóa thành công";
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
