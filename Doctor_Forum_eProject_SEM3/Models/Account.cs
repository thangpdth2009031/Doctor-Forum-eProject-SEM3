namespace Doctor_Forum_eProject_SEM3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Achievements = new HashSet<Achievement>();
            Experiences = new HashSet<Experience>();
            Professionals = new HashSet<Professional>();
            Qualifications = new HashSet<Qualification>();
            Replies = new HashSet<Reply>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public string Avatar { get; set; }
        [NotMapped]
        public HttpPostedFileBase AvatarFile { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Please enter your user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(20)] 
        public string GroupId { get; set; }
        [Required(ErrorMessage = "Please enter your full name")]
        [StringLength(250)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your address detail")]
        public string AddressDetail { get; set; }

        public int? DistrictId { get; set; }

        public int? ProvinceId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool Status { get; set; }

        public int? SpecializationId { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        [StringLength(250)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone")]
        [StringLength(15)]
        public string Phone { get; set; }

        public int? Gender { get; set; }

        public virtual Specialization Specialization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Achievement> Achievements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experience> Experiences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Professional> Professionals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Qualification> Qualifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
