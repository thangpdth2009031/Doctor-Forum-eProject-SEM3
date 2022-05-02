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
    public class AchievementsController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();

        // GET: Admin/Achievements
        public ActionResult Index()
        {
            var achievements = db.Achievements.Include(a => a.Account);
            return View(achievements.ToList());
        }

        // GET: Admin/Achievements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // GET: Admin/Achievements/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "UserName");
            return View();
        }

        // POST: Admin/Achievements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Description,AccountId,Status,CreatedAt,UpatedAt")] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                achievement.Status = true;
                achievement.CreatedAt = DateTime.Now;
                achievement.UpatedAt = DateTime.Now;
                db.Achievements.Add(achievement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "UserName", achievement.AccountId);
            return View(achievement);
        }

        // GET: Admin/Achievements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "UserName", achievement.AccountId);
            return View(achievement);
        }

        // POST: Admin/Achievements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Achievement achievement)
        {
            if (ModelState.IsValid)
            {

                achievement.UpatedAt = DateTime.Now;
                db.Entry(achievement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "UserName", achievement.AccountId);
            return View(achievement);
        }

        // GET: Admin/Achievements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
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
                var todo = db.Achievements.Find(TaskIds[i]);
                todo.Status = false;
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // POST: Admin/Achievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Achievement achievement = db.Achievements.Find(id);
            db.Achievements.Remove(achievement);
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
