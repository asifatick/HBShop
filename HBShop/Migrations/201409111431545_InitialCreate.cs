namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountMasters",
                c => new
                    {
                        AccountMasterId = c.Long(nullable: false, identity: true),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateTime = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountMasterId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Long(nullable: false, identity: true),
                        AccountName = c.String(),
                        Amount = c.Double(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Type = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Long(nullable: false, identity: true),
                        ClientName = c.String(),
                        Addressee = c.String(),
                        PhoneNo = c.String(),
                        MobilNo = c.String(),
                        Advance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Due = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CountryId = c.Long(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.CountryId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Long(nullable: false, identity: true),
                        ItemName = c.String(),
                        Size = c.String(),
                        ItemCode = c.String(),
                        ReorderLevel = c.Int(nullable: false),
                        StockInHand = c.Int(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Supplier_SupplierId = c.Long(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.CategoryId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.Supplier_SupplierId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Long(nullable: false, identity: true),
                        ItemId = c.Long(nullable: false),
                        OrderMasterId = c.Long(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUserId = c.String(maxLength: 128),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.OrderMasters", t => t.OrderMasterId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ItemId)
                .Index(t => t.OrderMasterId)
                .Index(t => t.UnitId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.OrderMasters",
                c => new
                    {
                        OrderMasterId = c.Long(nullable: false, identity: true),
                        ClientId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TotalAmount = c.Single(nullable: false),
                        Received = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderMasterId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ClientId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UnitId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.StockReceiveds",
                c => new
                    {
                        StockReceivedId = c.Long(nullable: false, identity: true),
                        ItemId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SupplierId = c.Long(nullable: false),
                        BatchNo = c.String(),
                        CostPerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitId = c.Long(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StockReceivedId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ItemId)
                .Index(t => t.SupplierId)
                .Index(t => t.UnitId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ContractParson = c.String(),
                        Address = c.String(),
                        PhoneNo = c.String(),
                        MobilNo = c.String(),
                        Deposit = c.Double(nullable: false),
                        CountryId = c.Long(nullable: false),
                        Advance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Due = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CountryId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockReceiveds", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StockReceiveds", "UnitId", "dbo.Units");
            DropForeignKey("dbo.StockReceiveds", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.StockReceiveds", "ItemId", "dbo.Items");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderDetails", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "UnitId", "dbo.Units");
            DropForeignKey("dbo.OrderMasters", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "OrderMasterId", "dbo.OrderMasters");
            DropForeignKey("dbo.OrderMasters", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.OrderDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Clients", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clients", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Categories", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Batches", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Suppliers", new[] { "User_Id" });
            DropIndex("dbo.Suppliers", new[] { "CountryId" });
            DropIndex("dbo.StockReceiveds", new[] { "ApplicationUserId" });
            DropIndex("dbo.StockReceiveds", new[] { "UnitId" });
            DropIndex("dbo.StockReceiveds", new[] { "SupplierId" });
            DropIndex("dbo.StockReceiveds", new[] { "ItemId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderMasters", new[] { "ApplicationUserId" });
            DropIndex("dbo.OrderMasters", new[] { "ClientId" });
            DropIndex("dbo.OrderDetails", new[] { "ApplicationUserId" });
            DropIndex("dbo.OrderDetails", new[] { "UnitId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderMasterId" });
            DropIndex("dbo.OrderDetails", new[] { "ItemId" });
            DropIndex("dbo.Items", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Items", new[] { "ApplicationUserId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Clients", new[] { "ApplicationUserId" });
            DropIndex("dbo.Clients", new[] { "CountryId" });
            DropIndex("dbo.Categories", new[] { "ApplicationUserId" });
            DropIndex("dbo.Batches", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Accounts", new[] { "ApplicationUserId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.StockReceiveds");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Units");
            DropTable("dbo.OrderMasters");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Items");
            DropTable("dbo.Countries");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
            DropTable("dbo.Batches");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountMasters");
        }
    }
}
