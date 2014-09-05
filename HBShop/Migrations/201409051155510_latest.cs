namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropPrimaryKey("dbo.Countries");
            DropColumn("dbo.Countries", "CountryId");
            AddColumn("dbo.Countries", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Countries", "Id");
            AddForeignKey("dbo.Clients", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "CountryId", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Clients", "CountryId", "dbo.Countries");
            DropPrimaryKey("dbo.Countries");
            DropColumn("dbo.Countries", "Id");
            AddPrimaryKey("dbo.Countries", "CountryId");
            AddForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
