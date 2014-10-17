namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Category_CategoryId", c => c.Long());
            AddColumn("dbo.Suppliers", "ContactPerson", c => c.String());
            CreateIndex("dbo.OrderDetails", "Category_CategoryId");
            AddForeignKey("dbo.OrderDetails", "Category_CategoryId", "dbo.Categories", "CategoryId");
            DropColumn("dbo.Suppliers", "ContractParson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "ContractParson", c => c.String());
            DropForeignKey("dbo.OrderDetails", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderDetails", new[] { "Category_CategoryId" });
            DropColumn("dbo.Suppliers", "ContactPerson");
            DropColumn("dbo.OrderDetails", "Category_CategoryId");
        }
    }
}
