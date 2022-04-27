namespace Doctor_Forum_eProject_SEM3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Experience
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        [StringLength(50)]
        public string StartYear { get; set; }

        [StringLength(50)]
        public string EndYear { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Workplace { get; set; }

        public string Position { get; set; }

        public virtual Account Account { get; set; }
    }
}
