namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5th : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "UnitId", "dbo.Units");
            DropPrimaryKey("dbo.Units");
            DropColumn("dbo.Units", "UnitId");
            AddColumn("dbo.Units", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Units", "Id");
            AddForeignKey("dbo.OrderDetails", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "UnitId", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.OrderDetails", "UnitId", "dbo.Units");
            DropPrimaryKey("dbo.Units");
            DropColumn("dbo.Units", "Id");
            AddPrimaryKey("dbo.Units", "UnitId");
            AddForeignKey("dbo.OrderDetails", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
        }
    }
}
