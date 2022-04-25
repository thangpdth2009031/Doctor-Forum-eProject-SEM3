namespace Doctor_Forum_eProject_SEM3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }

        public string Title { get; set; }
        [AllowHtml]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }

        public int Type { get; set; }

        public int SpecializationId { get; set; }

        public string Image { get; set; }

        public string AccountId { get; set; }

        public string Tag { get; set; }

        public bool Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }

        public virtual Account Account { get; set; }

        public virtual Specialization Specialization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
