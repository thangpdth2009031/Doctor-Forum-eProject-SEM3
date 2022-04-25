using Doctor_Forum_eProject_SEM3.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doctor_Forum_eProject_SEM3.Data
{
    public class MyIdentityDbContext : IdentityDbContext<Models.Account>
    {
        public MyIdentityDbContext() : base("ConnectionString")
        {

        }        
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Professional> Professionals { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }        
        public virtual DbSet<Specialization> Specializations { get; set; }

        public System.Data.Entity.DbSet<Doctor_Forum_eProject_SEM3.Models.ViewModel.AccountModel> AccountModels { get; set; }
    }
}