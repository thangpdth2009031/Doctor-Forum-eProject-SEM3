using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doctor_Forum_eProject_SEM3.Models.ViewModel
{
    public class AccountModel
    {        
        [Key]
        public int Id { get; set; }
        public string Avatar { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(250)]
        public string FullName { get; set; }

        public string AddressDetail { get; set; }

        public int? DistrictId { get; set; }

        public int? ProvinceId { get; set; }

        public int? SpecializationId { get; set; }

        [StringLength(250)]
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

        public string Wordplace { get; set; }

        public string Position { get; set; }

        public string ProfessionalName { get; set; }

        [StringLength(50)]
        public string YearAchievement { get; set; }

        public string DescriptionQualifications { get; set; }

        public string School { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}