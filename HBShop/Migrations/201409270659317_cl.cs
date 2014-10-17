namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Date");
        }
    }
}
