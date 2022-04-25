namespace Doctor_Forum_eProject_SEM3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 15),
                        Gender = c.Int(),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        AccountId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RoleId = c.Int(),
                        Avatar = c.String(),
                        Password = c.String(maxLength: 250),
                        FullName = c.String(maxLength: 250),
                        AddressDetail = c.String(),
                        DistrictId = c.Int(),
                        ProvinceId = c.Int(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        SpecializationId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId)
                .Index(t => t.SpecializationId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.String(maxLength: 50),
                        Description = c.String(),
                        AccountId = c.String(maxLength: 128),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.String(maxLength: 128),
                        StartYear = c.String(maxLength: 50),
                        EndYear = c.String(maxLength: 50),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Workplace = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Type = c.Int(nullable: false),
                        SpecializationId = c.Int(nullable: false),
                        Image = c.String(),
                        AccountId = c.String(maxLength: 128),
                        Tag = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ParenId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        AccountId = c.String(maxLength: 128),
                        Message = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Reply1_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Replies", t => t.Reply1_Id)
                .Index(t => t.PostId)
                .Index(t => t.AccountId)
                .Index(t => t.Reply1_Id);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RepId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Link = c.String(),
                        Status = c.Boolean(nullable: false),
                        Reply_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Replies", t => t.Reply_Id)
                .Index(t => t.Reply_Id);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Avatar = c.String(),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Password = c.String(maxLength: 50),
                        ConfirmPassword = c.String(maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 250),
                        AddressDetail = c.String(),
                        DistrictId = c.String(),
                        ProvinceId = c.String(),
                        SpecializationId = c.Int(),
                        Email = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(maxLength: 15),
                        Gender = c.Int(),
                        Year = c.String(maxLength: 50),
                        Description = c.String(),
                        StartYear = c.String(maxLength: 50),
                        EndYear = c.String(maxLength: 50),
                        DescriptionExperiences = c.String(),
                        Workplace = c.String(),
                        Position = c.String(),
                        ProfessionalName = c.String(),
                        YearAchievement = c.String(maxLength: 50),
                        DescriptionQualifications = c.String(),
                        School = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId)
                .Index(t => t.SpecializationId);
            
            CreateTable(
                "dbo.Professional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfessionalName = c.String(),
                        AccountId = c.String(maxLength: 128),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.String(maxLength: 50),
                        Description = c.String(),
                        AccountId = c.String(maxLength: 128),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        School = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Status = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Qualifications", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Professional", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.AspNetUsers", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.AccountModels", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.Replies", "Reply1_Id", "dbo.Replies");
            DropForeignKey("dbo.Replies", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Attachments", "Reply_Id", "dbo.Replies");
            DropForeignKey("dbo.Replies", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experiences", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Achievements", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AccountDetails", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Qualifications", new[] { "AccountId" });
            DropIndex("dbo.Professional", new[] { "AccountId" });
            DropIndex("dbo.AccountModels", new[] { "SpecializationId" });
            DropIndex("dbo.Attachments", new[] { "Reply_Id" });
            DropIndex("dbo.Replies", new[] { "Reply1_Id" });
            DropIndex("dbo.Replies", new[] { "AccountId" });
            DropIndex("dbo.Replies", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "AccountId" });
            DropIndex("dbo.Posts", new[] { "SpecializationId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Experiences", new[] { "AccountId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Achievements", new[] { "AccountId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "SpecializationId" });
            DropIndex("dbo.AccountDetails", new[] { "AccountId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Qualifications");
            DropTable("dbo.Professional");
            DropTable("dbo.AccountModels");
            DropTable("dbo.Specializations");
            DropTable("dbo.Attachments");
            DropTable("dbo.Replies");
            DropTable("dbo.Posts");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Experiences");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Achievements");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AccountDetails");
        }
    }
}
