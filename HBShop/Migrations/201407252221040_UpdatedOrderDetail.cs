namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "ItemId_ItemId", "dbo.Items");
            DropForeignKey("dbo.OrderMasters", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.OrderDetails", "OrderMasterId", "dbo.OrderMasters");
            DropIndex("dbo.OrderDetails", new[] { "ItemId_ItemId" });
            RenameColumn(table: "dbo.OrderDetails", name: "ItemId_ItemId", newName: "ItemId");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.OrderMasters");
            AddColumn("dbo.OrderDetails", "OrderMasterId", c => c.Long(nullable: false));
            AlterColumn("dbo.Clients", "ClientId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.OrderDetails", "ItemId", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderMasters", "OrderMasterId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.OrderMasters", "ClientId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Clients", "ClientId");
            AddPrimaryKey("dbo.OrderMasters", "OrderMasterId");
            CreateIndex("dbo.OrderDetails", "ItemId");
            CreateIndex("dbo.OrderDetails", "OrderMasterId");
            CreateIndex("dbo.OrderMasters", "ClientId");
            AddForeignKey("dbo.OrderMasters", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "OrderMasterId", "dbo.OrderMasters", "OrderMasterId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "ItemId", "dbo.Items", "ItemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.OrderDetails", "OrderMasterId", "dbo.OrderMasters");
            DropForeignKey("dbo.OrderMasters", "ClientId", "dbo.Clients");
            DropIndex("dbo.OrderMasters", new[] { "ClientId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderMasterId" });
            DropIndex("dbo.OrderDetails", new[] { "ItemId" });
            DropPrimaryKey("dbo.OrderMasters");
            DropPrimaryKey("dbo.Clients");
            AlterColumn("dbo.OrderMasters", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderMasters", "OrderMasterId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OrderDetails", "ItemId", c => c.Long());
            AlterColumn("dbo.Clients", "ClientId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.OrderDetails", "OrderMasterId");
            AddPrimaryKey("dbo.OrderMasters", "OrderMasterId");
            AddPrimaryKey("dbo.Clients", "ClientId");
            RenameColumn(table: "dbo.OrderDetails", name: "ItemId", newName: "ItemId_ItemId");
            CreateIndex("dbo.OrderDetails", "ItemId_ItemId");
            AddForeignKey("dbo.OrderDetails", "OrderMasterId", "dbo.OrderMasters", "OrderMasterId", cascadeDelete: true);
            AddForeignKey("dbo.OrderMasters", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "ItemId_ItemId", "dbo.Items", "ItemId");
        }
    }
}
