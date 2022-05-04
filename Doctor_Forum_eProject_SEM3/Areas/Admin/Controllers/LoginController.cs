using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doctor_Forum_eProject_SEM3.Common;
using Doctor_Forum_eProject_SEM3.Dao;
using Doctor_Forum_eProject_SEM3.Models;
using Doctor_Forum_eProject_SEM3.Models.ViewModel;

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login


        public ActionResult Login()
        {

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password), true);
                if (result == 1)
                {
                    var user = dao.GetById(model.Username);
                    var userSession = new Account();
                    userSession.UserName = user.UserName;
                    userSession.GroupId = user.GroupId;
                    userSession.Id = user.Id;
        
                    // var listCredentials = dao.GetListCredential(model.Username);
        
        
                    // userSession.GroupID = user.GroupID;
                    // var listCredentials = dao.GetListCredential(model.UserName);
        
                    // Session.Add(UserSession.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(UserSession.USER_SESSION, userSession);

                    TempData["result"] = "Đặng nhập thành công";
                    return RedirectToAction("Index", "HomeAdmin");
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
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
        
            return View("Index");
        }
        
        }
    }
