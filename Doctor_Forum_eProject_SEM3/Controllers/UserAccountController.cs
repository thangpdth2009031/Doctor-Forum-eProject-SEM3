
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Dao;
using Doctor_Forum_eProject_SEM3.Models;
using Doctor_Forum_eProject_SEM3.Models.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class UserAccountController : Controller
    {
        private DoctorForumDbContext db = null;

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
           
            DateTime dateTimeNow = DateTime.Now;
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(accountModel.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(accountModel.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var account = new Account();

                    account.RoleId = 1;
                    account.GroupId = "MEMBER";
                    account.Avatar = accountModel.Avatar;
                    account.UserName = accountModel.UserName;
                    account.Password = Encryptor.MD5Hash(accountModel.Password);
                    account.FullName = accountModel.FullName;
                    account.AddressDetail = accountModel.AddressDetail;
                    account.Email = accountModel.Email;
                    account.Phone = accountModel.Phone;
                    account.Gender = (int)accountModel.Gender;
                    account.SpecializationId = (int)accountModel.SpecializationId;
                    ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name");

                    account.CreatedAt = dateTimeNow;
                    account.UpdatedAt = dateTimeNow;
                    account.Status = true;
                    if (!string.IsNullOrEmpty(accountModel.ProvinceId))
                    {
                        account.ProvinceId = int.Parse(accountModel.ProvinceId);
                    }
                    if (!string.IsNullOrEmpty(accountModel.ProvinceId))
                    {
                        account.DistrictId = int.Parse(accountModel.DistrictId);
                    }
                //     db.Accounts.Add(account);
                //     int pk = account.Id;
                //     var achievement = new Achievement()
                //     {
                //         Year = accountModel.YearAchievement,
                //         Description = accountModel.Description,
                //         AccountId = pk,
                //         Status = true,
                //         CreatedAt = DateTime.Now,
                //         UpatedAt = DateTime.Now,
                //         
                // };
                //     var professional = new Professional()
                //     {
                //         ProfessionalName = accountModel.ProfessionalName,
                //         AccountId = pk,
                //         Status = true,
                //         CreatedAt = DateTime.Now,
                //         UpdatedAt = DateTime.Now
                //     };
                //     var qualification = new Qualification()
                //     {
                //         Year = accountModel.Year,
                //         Description = accountModel.Description,
                //         School = accountModel.School,
                //         AccountId = pk,
                //         Status = true,
                //         CreatedAt = DateTime.Now,
                //         UpdatedAt = DateTime.Now,
                //     };
                //     var experience = new Experience()
                //     {
                //         StartYear = accountModel.StartYear,
                //         EndYear = accountModel.EndYear,
                //         Description = accountModel.DescriptionExperiences,
                //         Workplace = accountModel.Workplace,
                //         Position = accountModel.Position,
                //         AccountId = pk,
                //         Status = true,
                //         CreatedAt = DateTime.Now,
                //         UpdatedAt = DateTime.Now
                //     };
                    var result = dao.Insert(account);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        accountModel = new AccountModel();
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
                
            }
            
            return View(accountModel);
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
        public ActionResult Logout()
        {
            Session[UserSession.USER_SESSION] = null;
            return Redirect("/");
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
        public ActionResult UserProfile(int? id)
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
            ViewBag.Professional = db.Professionals.Where(p => p.AccountId == (account.Id)).ToList();
            ViewBag.Qualification = db.Qualifications.Where(p => p.AccountId == (account.Id)).ToList();
            ViewBag.Experience = db.Experiences.Where(p => p.AccountId == (account.Id)).ToList();
            ViewBag.Post = db.Posts.Where((x => x.Status == (true) && x.AccountId == (account.Id))).ToList();
            return View(account);
        }
        public ActionResult AccountProfile()
        {
            var account = (Account)Session[UserSession.USER_SESSION];
            if (account == null)
            {
                return RedirectToAction("Login", "UserAccount");
            }
            else
            {
                ViewBag.Professional = db.Professionals.Where(p => p.AccountId == (account.Id)).ToList();
                ViewBag.Qualification = db.Qualifications.Where(p => p.AccountId == (account.Id)).ToList();
                ViewBag.Experience = db.Experiences.Where(p => p.AccountId == (account.Id)).ToList();
                var post = db.Posts.Where((x => x.Status == (true) && x.AccountId == (account.Id))).ToList();
                return View(post);
            }
        }
    }
}