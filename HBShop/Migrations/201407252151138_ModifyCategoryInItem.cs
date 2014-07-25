namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCategoryInItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.Items", "CategoryId_CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryId_CategoryId" });
            DropIndex("dbo.Items", new[] { "UserId_AccountMasterId" });
            RenameColumn(table: "dbo.Items", name: "CategoryId_CategoryId", newName: "CategoryId");
            AddColumn("dbo.Items", "ApplicationUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Items", "CategoryId", c => c.Long(nullable: false));
            CreateIndex("dbo.Items", "CategoryId");
            CreateIndex("dbo.Items", "ApplicationUserId");
            AddForeignKey("dbo.Items", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Items", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Items", "UserId_AccountMasterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "UserId_AccountMasterId", c => c.Int());
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Items", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "ApplicationUserId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            AlterColumn("dbo.Items", "CategoryId", c => c.Long());
            DropColumn("dbo.Items", "ApplicationUserId");
            RenameColumn(table: "dbo.Items", name: "CategoryId", newName: "CategoryId_CategoryId");
            CreateIndex("dbo.Items", "UserId_AccountMasterId");
            CreateIndex("dbo.Items", "CategoryId_CategoryId");
            AddForeignKey("dbo.Items", "CategoryId_CategoryId", "dbo.Categories", "CategoryId");
            AddForeignKey("dbo.Items", "UserId_AccountMasterId", "dbo.AccountMasters", "AccountMasterId");
        }
    }
}
