namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Units", "UpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Units", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Units", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Units", "User_Id");
            AddForeignKey("dbo.Units", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Units", new[] { "User_Id" });
            DropColumn("dbo.Units", "User_Id");
            DropColumn("dbo.Units", "IsDeleted");
            DropColumn("dbo.Units", "UpdateDate");
        }
    }
}
