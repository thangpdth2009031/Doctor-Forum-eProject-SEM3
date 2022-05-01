
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doctor_Forum_eProject_SEM3.Models.ViewModel
{
    public class AccountModel
    {        
        [Key]
        public int Id { get; set; }
        public string Avatar { get; set; }
        [NotMapped]
        public HttpPostedFileBase AvatarFile { get; set; }
        [StringLength(250)]

        [Required(ErrorMessage = "Please enter your username")]
        public string UserName { get; set; }

        [StringLength(50, ErrorMessage = "Maximum 100 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }


        [StringLength(50, ErrorMessage = "Maximum 100 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string ConfirmPassword { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Please enter your full name")]
        public string FullName { get; set; }


        public string AddressDetail { get; set; }

        public string DistrictId { get; set; }

        public string ProvinceId { get; set; }

        public int? SpecializationId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public int? Gender { get; set; }

        [StringLength(50)]
        public string Year { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string StartYear { get; set; }

        [StringLength(50)]
        public string EndYear { get; set; }

        public string DescriptionExperiences { get; set; }

        public string Workplace { get; set; }

        public string Position { get; set; }

        public string ProfessionalName { get; set; }

        [StringLength(50)]
        public string YearAchievement { get; set; }

        public string DescriptionQualifications { get; set; }

        public string School { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}