using Doctor_Forum_eProject_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor_Forum_eProject_SEM3.Controllers
{
    public class DoctorController : Controller
    {
        private DoctorForumDbContext db = new DoctorForumDbContext();
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListDoctor()
        {
            ViewBag.Specialization = new SelectList(db.Specializations.Where(x => x.Status == true), "Id", "Name");
            var listDoctor = db.Accounts.Where(x => x.Status == true).ToList();
            return View(listDoctor);
        }
        [HttpPost]
        public ActionResult ListDoctor(string keyword, int? ProvinceId, int? DistrictId, int? Specialization)
        {
            try
            {
                //Chỉ nhập tìm kiếm không chọn tỉnh, huyện, chuyên ngành
                if (keyword != "" && ProvinceId == null && Specialization == null)
                {
                    var doctors = db.Accounts.Where(s => s.FullName.Contains(keyword));
                    return View(doctors.ToList());
                }
                // Chỉ chọn tỉnh
                else if (ProvinceId != null && keyword == "" && Specialization == null && DistrictId == null)
                {
                    var doctors = db.Accounts.Where(s => s.ProvinceId == ProvinceId.Value);
                    return View(doctors.ToList());
                }
                // Chọn tỉnh + huyện
                else if (ProvinceId != null && DistrictId != null && keyword == "" && Specialization == null)
                {
                    var doctors = db.Accounts.Where(s => s.ProvinceId == ProvinceId.Value && s.DistrictId == DistrictId.Value);
                    return View(doctors.ToList());
                }
                //chọn chuyên ngành
                else if (Specialization != null && keyword == "" && ProvinceId == null)
                {
                    var doctors = db.Accounts.Where(s => s.SpecializationId == Specialization.Value);
                    return View(doctors.ToList());
                }
                //chọn từ khóa + chuyên ngành
                else if (keyword != "" && Specialization != null && ProvinceId == null)
                {
                    var doctors = db.Accounts.Where(s => s.FullName.Contains(keyword) && s.SpecializationId == Specialization);
                    return View(doctors.ToList());
                }
                //chọn từ khóa + tỉnh
                else if (keyword != "" && ProvinceId != null && Specialization == null)
                {
                    var doctors = db.Accounts.Where(s => s.FullName.Contains(keyword) && s.ProvinceId == ProvinceId.Value);
                    return View(doctors.ToList());
                }
                //chọn từ khóa + tỉnh + huyện
                else if (keyword != "" && ProvinceId != null && DistrictId != null && Specialization == null)
                {
                    var doctors = db.Accounts.Where(s => s.FullName.Contains(keyword) && s.ProvinceId == ProvinceId.Value && s.DistrictId == DistrictId.Value);
                    return View(doctors.ToList());
                }
                else
                {
                    var doctors = db.Accounts.Where(s => s.FullName.Contains(keyword) && s.DistrictId == DistrictId.Value && s.SpecializationId == Specialization.Value);
                    return View(doctors.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}