using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doctor_Forum_eProject_SEM3.Models.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui Lòng nhập tên đăng nhập")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui Lòng nhập mật khẩu")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}