namespace Doctor_Forum_eProject_SEM3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droptableaccountdetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccountDetails", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.AccountDetails", new[] { "AccountId" });
            DropTable("dbo.AccountDetails");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AccountDetails", "AccountId");
            AddForeignKey("dbo.AccountDetails", "AccountId", "dbo.AspNetUsers", "Id");
        }
    }
}
