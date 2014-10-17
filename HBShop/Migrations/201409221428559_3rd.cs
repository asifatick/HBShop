namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockReceiveds", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Clients", "CountryId", "dbo.Countries");
            DropIndex("dbo.Clients", new[] { "CountryId" });
            DropIndex("dbo.StockReceiveds", new[] { "UnitId" });
            RenameColumn(table: "dbo.Clients", name: "CountryId", newName: "Country_Id");
            RenameColumn(table: "dbo.Clients", name: "ApplicationUserId", newName: "User_Id");
            RenameColumn(table: "dbo.OrderDetails", name: "ApplicationUserId", newName: "User_Id");
            RenameColumn(table: "dbo.StockReceiveds", name: "ApplicationUserId", newName: "User_Id");
            RenameIndex(table: "dbo.Clients", name: "IX_ApplicationUserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_ApplicationUserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.StockReceiveds", name: "IX_ApplicationUserId", newName: "IX_User_Id");
            AlterColumn("dbo.Clients", "Country_Id", c => c.Long());
            CreateIndex("dbo.Clients", "Country_Id");
            AddForeignKey("dbo.Clients", "Country_Id", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Clients", new[] { "Country_Id" });
            AlterColumn("dbo.Clients", "Country_Id", c => c.Long(nullable: false));
            RenameIndex(table: "dbo.StockReceiveds", name: "IX_User_Id", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_User_Id", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.Clients", name: "IX_User_Id", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.StockReceiveds", name: "User_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.OrderDetails", name: "User_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Clients", name: "User_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Clients", name: "Country_Id", newName: "CountryId");
            CreateIndex("dbo.StockReceiveds", "UnitId");
            CreateIndex("dbo.Clients", "CountryId");
            AddForeignKey("dbo.Clients", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StockReceiveds", "UnitId", "dbo.Units", "UnitId", cascadeDelete: true);
        }
    }
}
