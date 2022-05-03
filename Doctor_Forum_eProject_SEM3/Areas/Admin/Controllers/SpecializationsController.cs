using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Doctor_Forum_eProject_SEM3.Models;

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class SpecializationsController : BaseController
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();

        // GET: Admin/Specializations
        public ActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }


            return View(db.Specializations.ToList());
        }

        // GET: Admin/Specializations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // GET: Admin/Specializations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Specializations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                specialization.Status = true;
                specialization.CreatedAt = DateTime.Now;
                specialization.UpdatedAt = DateTime.Now;
                db.Specializations.Add(specialization);
                db.SaveChanges();


                TempData["result"] = "Thêm mới thành công";

                return RedirectToAction("Index");
            }

            return View(specialization);
        }

        // GET: Admin/Specializations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // POST: Admin/Specializations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                specialization.UpdatedAt = DateTime.Now;
                db.Entry(specialization).State = EntityState.Modified;
                db.SaveChanges();
                TempData["result"] = "Sửa thành công";
                return RedirectToAction("Index");
            }
            return View(specialization);
        }

        // GET: Admin/Specializations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // POST: Admin/Specializations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialization specialization = db.Specializations.Find(id);
            db.Specializations.Remove(specialization);
            db.SaveChanges();
            TempData["result"] = "Sửa thành công";
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
                var todo = db.Specializations.Find(TaskIds[i]);
                todo.Status = false;
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
            }
            TempData["result"] = "Xóa hết thành công";
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
