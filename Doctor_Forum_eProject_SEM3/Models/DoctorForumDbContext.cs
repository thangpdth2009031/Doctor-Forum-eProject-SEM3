using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Doctor_Forum_eProject_SEM3.Models
{
    public partial class DoctorForumDbContext : DbContext
    {
        public DoctorForumDbContext()
            : base("name=DoctorForumDbContext")
        {
        }

        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Professional> Professionals { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountGroup>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleId)
                .IsUnicode(false);

            modelBuilder.Entity<Experience>()
                .Property(e => e.StartYear)
                .IsFixedLength();

            modelBuilder.Entity<Experience>()
                .Property(e => e.EndYear)
                .IsFixedLength();

            modelBuilder.Entity<Qualification>()
                .Property(e => e.Year)
                .IsFixedLength();

            modelBuilder.Entity<Reply>()
                .HasMany(e => e.Attachments)
                .WithOptional(e => e.Reply)
                .HasForeignKey(e => e.RepId);

            modelBuilder.Entity<Reply>()
                .HasMany(e => e.Replies1)
                .WithOptional(e => e.Reply1)
                .HasForeignKey(e => e.ParenId);

            modelBuilder.Entity<Role>()
                .Property(e => e.Id)
                .IsUnicode(false);
        }
    }
}
