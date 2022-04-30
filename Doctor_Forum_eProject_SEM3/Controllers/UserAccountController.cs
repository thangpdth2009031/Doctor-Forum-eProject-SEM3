
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Dao;
using Doctor_Forum_eProject_SEM3.Models;
using Doctor_Forum_eProject_SEM3.Models.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class UserAccountController : Controller
    {   
        private DoctorForumDbContext db;        
        public UserAccountController()
        {
            db = new DoctorForumDbContext();           
        }
        
        public ActionResult Register()
        {
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountModel accountModel)
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
                return View(accountModel);

            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", accountModel.SpecializationId);
            return RedirectToAction("Index", "Posts");
        }     

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.Username);
                    var userSession = new Account();
                    userSession = user;
                    Session.Add(UserSession.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }

            return View(model);
        }

   /*     [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            SignInManager<Account, string> signInManager;
            // sử dụng userManager để check thông tin đăng nhập.d
            var account = await userManager.FindAsync(model.Username, model.Password);
            if (account != null)
            {
                // đăng nhập  thành công thì dùng SignInManager để lưu lại thông tin vừa đăng nhập.
                signInManager = new SignInManager<Account, string>(userManager, Request.GetOwinContext().Authentication);
                await signInManager.SignInAsync(account, isPersistent: false, rememberBrowser: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }*/
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
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

        public ActionResult UserProfile()
        {           
            return View();
        }
    }
}