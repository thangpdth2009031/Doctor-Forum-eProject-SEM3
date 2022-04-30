namespace Doctor_Forum_eProject_SEM3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Credential")]
    [Serializable]
    public partial class Credential
    {
        [Key]
        [Column(Order = 0)]
        [MaxLength(20)]
        public byte[] AccountGroupId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RoleId { get; set; }
    }
}
