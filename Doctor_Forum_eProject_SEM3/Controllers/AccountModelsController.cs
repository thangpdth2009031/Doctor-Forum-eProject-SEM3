using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Models;
using Doctor_Forum_eProject_SEM3.Models.ViewModel;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class AccountModelsController : Controller
    {
        /*private DoctorForumDbContext db = new DoctorForumDbContext();*/

        // GET: AccountModels
        DoctorForumDbContext db = new DoctorForumDbContext();
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
        public ActionResult Create(AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.RoleId = 1;
                account.Avatar = accountModel.Avatar;
                account.UserName = accountModel.UserName;
                account.Password = Encryptor.MD5Hash(accountModel.UserName);
                account.FullName = accountModel.FullName;
                account.AddressDetail = accountModel.AddressDetail;
                account.SpecializationId = accountModel.SpecializationId;
                account.CreatedAt = DateTime.Now;
                account.UpdatedAt = DateTime.Now;
                account.Status = true;
                if (!string.IsNullOrEmpty(accountModel.ProvinceId))
                {
                    account.ProvinceId = int.Parse(accountModel.ProvinceId);
                }
                if (!string.IsNullOrEmpty(accountModel.ProvinceId))
                {
                    account.DistrictId = int.Parse(accountModel.DistrictId);
                }
                db.Accounts.Add(account);
                int pk = account.Id;
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
                db.AccountDetails.Add(accountDetail);
                Achievement achievement = new Achievement()
                {
                    Year = accountModel.YearAchievement,
                    Description = accountModel.Description,
                    AccountId = pk,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    UpatedAt = DateTime.Now
                };
                db.Achievements.Add(achievement);
                Professional professional = new Professional()
                {
                    ProfessionalName = accountModel.ProfessionalName,
                    AccountId = pk,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                db.Professionals.Add(professional);
                Qualification qualification = new Qualification()
                {
                    Year = accountModel.Year,
                    Description = accountModel.Description,
                    School = accountModel.School,
                    AccountId = pk,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                db.Qualifications.Add(qualification);
                Experience experience = new Experience()
                {
                    StartYear = accountModel.StartYear,
                    EndYear = accountModel.EndYear,
                    Description = accountModel.DescriptionExperiences,
                    Workplace = accountModel.Workplace,
                    Position = accountModel.Position,
                    AccountId = pk,
                    Status = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                db.Experiences.Add(experience);
                db.SaveChanges();
                return View();

            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", accountModel.SpecializationId);
            return View(accountModel);
        }
        public ActionResult Login()
        {

            return View();
        }
        public JsonResult LoadProvince()
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Content/data/Provinces_Data.xml"));

            var xElements = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "province");
            var list = new List<ProvinceModel>();
            ProvinceModel province = null;
            foreach (var item in xElements)
            {
                province = new ProvinceModel();
                province.ID = int.Parse(item.Attribute("id").Value);
                province.Name = item.Attribute("value").Value;
                list.Add(province);

            }
            return Json(new
            {
                data = list,
                status = true
            });
        }
        public JsonResult LoadDistrict(int provinceID)
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Content/data/Provinces_Data.xml"));

            var xElement = xmlDoc.Element("Root").Elements("Item")
                .Single(x => x.Attribute("type").Value == "province" && int.Parse(x.Attribute("id").Value) == provinceID);

            var list = new List<DistrictModel>();
            DistrictModel district = null;
            foreach (var item in xElement.Elements("Item").Where(x => x.Attribute("type").Value == "district"))
            {
                district = new DistrictModel();
                district.ID = int.Parse(item.Attribute("id").Value);
                district.Name = item.Attribute("value").Value;
                district.ProvinceID = int.Parse(xElement.Attribute("id").Value);
                list.Add(district);

            }
            return Json(new
            {
                data = list,
                status = true
            });
        }
    }
}
