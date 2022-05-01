namespace Doctor_Forum_eProject_SEM3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Professional")]
    public partial class Professional
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your professional name")]
        public string ProfessionalName { get; set; }

        public int? AccountId { get; set; }

        public bool Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual Account Account { get; set; }
    }
}
