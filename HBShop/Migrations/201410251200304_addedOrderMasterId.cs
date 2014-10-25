namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrderMasterId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "OrderMaster_OrderMasterId", "dbo.OrderMasters");
            DropIndex("dbo.OrderDetails", new[] { "OrderMaster_OrderMasterId" });
            RenameColumn(table: "dbo.OrderDetails", name: "OrderMaster_OrderMasterId", newName: "OrderMasterId");
            AlterColumn("dbo.OrderDetails", "OrderMasterId", c => c.Long());
            CreateIndex("dbo.OrderDetails", "OrderMasterId");
            AddForeignKey("dbo.OrderDetails", "OrderMasterId", "dbo.OrderMasters", "OrderMasterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderMasterId", "dbo.OrderMasters");
            DropIndex("dbo.OrderDetails", new[] { "OrderMasterId" });
            AlterColumn("dbo.OrderDetails", "OrderMasterId", c => c.Long());
            RenameColumn(table: "dbo.OrderDetails", name: "OrderMasterId", newName: "OrderMaster_OrderMasterId");
            CreateIndex("dbo.OrderDetails", "OrderMaster_OrderMasterId");
            AddForeignKey("dbo.OrderDetails", "OrderMaster_OrderMasterId", "dbo.OrderMasters", "OrderMasterId");
        }
    }
}
