namespace HBShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountMasters",
                c => new
                    {
                        AccountMasterId = c.Int(nullable: false, identity: true),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.AccountMasterId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.UserId_AccountMasterId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        Amount = c.Single(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Type = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.UserId_AccountMasterId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.UserId_AccountMasterId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        Addressee = c.String(),
                        PhoneNo = c.String(),
                        MobilNo = c.String(),
                        TotalReceive = c.Single(nullable: false),
                        TotalPaid = c.Single(nullable: false),
                        Advance = c.Single(nullable: false),
                        Due = c.Single(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.UserId_AccountMasterId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ContractParson = c.String(),
                        Addressee = c.String(),
                        PhoneNo = c.String(),
                        MobilNo = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.UserId_AccountMasterId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        ExpenseName = c.String(),
                        Amount = c.Single(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        AccountId_AccountId = c.Int(),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Accounts", t => t.AccountId_AccountId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.AccountId_AccountId)
                .Index(t => t.UserId_AccountMasterId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Long(nullable: false, identity: true),
                        ItemName = c.String(),
                        Size = c.String(),
                        ItemCode = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CategoryId_CategoryId = c.Long(),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Categories", t => t.CategoryId_CategoryId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.CategoryId_CategoryId)
                .Index(t => t.UserId_AccountMasterId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ItemId_ItemId = c.Long(),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Items", t => t.ItemId_ItemId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.ItemId_ItemId)
                .Index(t => t.UserId_AccountMasterId);
            
            CreateTable(
                "dbo.OrderMasters",
                c => new
                    {
                        OrderMasterId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TotalAmount = c.Single(nullable: false),
                        Received = c.Single(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderMasterId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.UserId_AccountMasterId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ItemId_ItemId = c.Long(),
                        SupplierId_SupplierId = c.Long(),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.StockId)
                .ForeignKey("dbo.Items", t => t.ItemId_ItemId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId_SupplierId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.ItemId_ItemId)
                .Index(t => t.SupplierId_SupplierId)
                .Index(t => t.UserId_AccountMasterId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ContractParson = c.String(),
                        Addressee = c.String(),
                        PhoneNo = c.String(),
                        MobilNo = c.String(),
                        Deposit = c.Double(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId_AccountMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.AccountMasters", t => t.UserId_AccountMasterId)
                .Index(t => t.UserId_AccountMasterId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Stocks", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.Stocks", "SupplierId_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.Stocks", "ItemId_ItemId", "dbo.Items");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderMasters", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.OrderDetails", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.OrderDetails", "ItemId_ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.Items", "CategoryId_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Expenses", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.Expenses", "AccountId_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Companies", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.Clients", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.Categories", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.Accounts", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropForeignKey("dbo.AccountMasters", "UserId_AccountMasterId", "dbo.AccountMasters");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Suppliers", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.Stocks", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.Stocks", new[] { "SupplierId_SupplierId" });
            DropIndex("dbo.Stocks", new[] { "ItemId_ItemId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderMasters", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.OrderDetails", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.OrderDetails", new[] { "ItemId_ItemId" });
            DropIndex("dbo.Items", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.Items", new[] { "CategoryId_CategoryId" });
            DropIndex("dbo.Expenses", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.Expenses", new[] { "AccountId_AccountId" });
            DropIndex("dbo.Companies", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.Clients", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.Categories", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.Accounts", new[] { "UserId_AccountMasterId" });
            DropIndex("dbo.AccountMasters", new[] { "UserId_AccountMasterId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Stocks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderMasters");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Items");
            DropTable("dbo.Expenses");
            DropTable("dbo.Companies");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountMasters");
        }
    }
}
