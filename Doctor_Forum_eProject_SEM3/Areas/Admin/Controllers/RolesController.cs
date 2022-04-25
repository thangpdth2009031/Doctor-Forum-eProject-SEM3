using Doctor_Forum_eProject_SEM3.Data;
using Doctor_Forum_eProject_SEM3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Forum_eProject_SEM3.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private MyIdentityDbContext db;
        private RoleManager<Role> roleManager; // quản lý role, quyền.
        // GET: Admin/Roles
        public RolesController()
        {
            db = new MyIdentityDbContext();
            // tạo mới role Manager
            RoleStore<Role> roleStore = new RoleStore<Role>(db);
            roleManager = new RoleManager<Role>(roleStore);
        }
        public async Task<ActionResult> AddRole()
        {
            Role role = new Role();
            role.Name = "Admin";
            role.Status = true;
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return View("CreateAccountSuccess");
            }
            else
            {
                return View("CreateAccountFails");
            }
        }
    }
}