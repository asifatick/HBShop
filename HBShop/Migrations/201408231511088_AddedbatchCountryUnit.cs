namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedbatchCountryUnit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Suppliers", name: "ApplicationUserId", newName: "User_Id");
            RenameIndex(table: "dbo.Suppliers", name: "IX_ApplicationUserId", newName: "IX_User_Id");
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BatchName = c.String(),
                        Date = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Items", "Supplier_SupplierId", c => c.Long());
            CreateIndex("dbo.Items", "Supplier_SupplierId");
            AddForeignKey("dbo.Items", "Supplier_SupplierId", "dbo.Suppliers", "SupplierId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Batches", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Batches", new[] { "User_Id" });
            DropColumn("dbo.Items", "Supplier_SupplierId");
            DropTable("dbo.Batches");
            RenameIndex(table: "dbo.Suppliers", name: "IX_User_Id", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.Suppliers", name: "User_Id", newName: "ApplicationUserId");
        }
    }
}
