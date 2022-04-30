namespace Doctor_Forum_eProject_SEM3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial  class Role
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
