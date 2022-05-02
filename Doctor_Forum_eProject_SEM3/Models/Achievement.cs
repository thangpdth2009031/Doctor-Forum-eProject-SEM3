namespace Doctor_Forum_eProject_SEM3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Achievement
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your year")]
        [StringLength(50)]
        public string Year { get; set; }
        [Required(ErrorMessage = "Please enter your description")]
        public string Description { get; set; }

        public int? AccountId { get; set; }

        public bool Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpatedAt { get; set; }

        public virtual Account Account { get; set; }
    }
}
