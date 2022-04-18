using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Doctor_Forum_eProject_SEM3.Models;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class RepliesController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();

        // GET: Replies
        public ActionResult Index()
        {
            var replies = db.Replies.Include(r => r.Account).Include(r => r.Post).Include(r => r.Reply1);
            return View(replies.ToList());
        }

        // GET: Replies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // GET: Replies/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar");
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title");
            ViewBag.ParenId = new SelectList(db.Replies, "Id", "Message");
            return View();
        }

        // POST: Replies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ParenId,PostId,AccountId,Message,Status,CreatedAt,UpdatedAt")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Replies.Add(reply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar", reply.AccountId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", reply.PostId);
            ViewBag.ParenId = new SelectList(db.Replies, "Id", "Message", reply.ParenId);
            return View(reply);
        }

        // GET: Replies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar", reply.AccountId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", reply.PostId);
            ViewBag.ParenId = new SelectList(db.Replies, "Id", "Message", reply.ParenId);
            return View(reply);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ParenId,PostId,AccountId,Message,Status,CreatedAt,UpdatedAt")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Avatar", reply.AccountId);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", reply.PostId);
            ViewBag.ParenId = new SelectList(db.Replies, "Id", "Message", reply.ParenId);
            return View(reply);
        }

        // GET: Replies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply reply = db.Replies.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reply reply = db.Replies.Find(id);
            db.Replies.Remove(reply);
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
