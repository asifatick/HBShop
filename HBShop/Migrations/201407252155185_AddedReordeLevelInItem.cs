namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReordeLevelInItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ReorderLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ReorderLevel");
        }
    }
}
