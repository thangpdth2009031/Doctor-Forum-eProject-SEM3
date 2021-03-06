using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Dao;
using Doctor_Forum_eProject_SEM3.Models;
using Doctor_Forum_eProject_SEM3.Models.ViewModel;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class AccountModelsController : Controller
    {
        private DoctorForumDbContext db;
        public AccountModelsController()
        {
            db = new DoctorForumDbContext();
        }

        /*public ActionResult ListAccount()
        {
            return View(db.Accounts.ToList());
        }*/

        public ActionResult Create()
        {
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name");
            return View();
        }
        public ActionResult AccountProfile()
        {
            /* if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Account account = db.Accounts.Find(id);
             if (account == null)
             {
                 return HttpNotFound();
             }*/
            return View();
        }

        // POST: AccountModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountModel accountModel)
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
                    Account account = new Account();
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
                    account.SpecializationId = accountModel.SpecializationId;
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
                   /* var result = dao.Insert(account);*/
                    db.SaveChanges();
                    /* if (result > 0)
                     {
                         ViewBag.Success = "Đăng ký thành công";
                         accountModel = new AccountModel();
                         return RedirectToAction("Index", "Home");
                     }
                     else
                     {
                         ModelState.AddModelError("", "Đăng ký không thành công.");
                     }
                     return View(accountModel);*/
                    return View(accountModel);

                }
                ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", accountModel.SpecializationId);
                return View(accountModel);
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Name", accountModel.SpecializationId);
            return RedirectToAction("Index", "Home");
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
        /*        [HttpPost]
                public async Task<ActionResult> Login(LoginModel model)
                {
                    SignInManager<Account, string> signInManager;
                    // sử dụng userManager để check thông tin đăng nhập.d
                    var account = await userManager.FindAsync(model.Username, model.Password);
                    if (account == null)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại.");
                    }
                    else
                    {
                        if (account.Status == false)
                        {
                            ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                        }
                        else
                        {
                            if (account.Password == model.Password)
                            {

                                // đăng nhập  thành công thì dùng SignInManager để lưu lại thông tin vừa đăng nhập.
                                signInManager = new SignInManager<Account, string>(userManager, Request.GetOwinContext().Authentication);
                                await signInManager.SignInAsync(account, isPersistent: false, rememberBrowser: false);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Mật khẩu không đúng.");
                            }
                        }

                    }
                    return View(model);
                }*/
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

        
    }
}
