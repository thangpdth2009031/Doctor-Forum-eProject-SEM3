/*using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Doctor_Forum_eProject_SEM3.Models;
using Doctor_Forum_eProject_SEM3.Models.ViewModel;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class AccountModelsController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();

        // GET: AccountModels
        public ActionResult Index()
        {
            var accountModels = db.AccountModels.Include(a => a.Specialization);
            return View(accountModels.ToList());
        }

        // GET: AccountModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel accountModel = db.AccountModels.Find(id);
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            return View(accountModel);
        }

        // GET: AccountModels/Create
        public ActionResult Create()
        {
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name");
            return View();
        }

        // POST: AccountModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(AccountModel accountModel)
        {
            
            if (ModelState.IsValid)
            {
                using (DoctorForumDbContext dc = new DoctorForumDbContext())
                {                    
                    Account account = new Account()
                    {
                        RoleId = 1,
                        Avatar = accountModel.Avatar,
                        UserName = accountModel.UserName,
                        Password = accountModel.UserName,
                        FullName = accountModel.FullName,
                        AddressDetail = accountModel.AddressDetail,
                        SpecializationId = accountModel.SpecializationId,
                        DistrictId = accountModel.DistrictId,
                        ProvinceId = accountModel.ProvinceId,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Status = true
                    };
                    await db.Accounts.AddAsync(account);
                    await db.SaveChangesAsync(); // Lưu các thay đổi đã xảy ra. khóa chính trong được chèn trong behaviorCase
                    int pk = account.Id;  // Bạn có thể lấy khóa chính của hàng đã chèn của mình                  
                    AccountDetail accountDetail = new AccountDetail()
                    {
                        Email = accountModel.Email,
                        Phone = accountModel.Phone,
                        Gender = accountModel.Gender,
                        Status = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        AccountId = pk
                    };                                       
                    object p = await db.AccountDetails.AddAsync(accountDetail);
                    await db.SaveChangesAsync();
                    return View();

                }
                
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", accountModel.SpecializationId);
            return View(accountModel);
        }

        // GET: AccountModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel accountModel = db.AccountModels.Find(id);
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", accountModel.SpecializationId);
            return View(accountModel);
        }

        // POST: AccountModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Avatar,UserName,Password,FullName,AddressDetail,DistrictId,ProvinceId,SpecializationId,Email,Phone,Gender,Year,Description,StartYear,EndYear,DescriptionExperiences,Wordplace,Position,ProfessionalName,YearAchievement,DescriptionQualifications,School")] AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", accountModel.SpecializationId);
            return View(accountModel);
        }

        // GET: AccountModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel accountModel = db.AccountModels.Find(id);
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            return View(accountModel);
        }

        // POST: AccountModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountModel accountModel = db.AccountModels.Find(id);
            db.AccountModels.Remove(accountModel);
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
*/