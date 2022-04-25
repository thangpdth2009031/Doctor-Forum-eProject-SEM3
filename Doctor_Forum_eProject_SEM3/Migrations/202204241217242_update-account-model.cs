namespace Doctor_Forum_eProject_SEM3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateaccountmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.Int());
        }
    }
}
