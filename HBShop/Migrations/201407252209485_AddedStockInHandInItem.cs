namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStockInHandInItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "StockInHand", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "StockInHand");
        }
    }
}
