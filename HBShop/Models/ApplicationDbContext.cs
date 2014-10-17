using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<HBShop.Models.Account> Accounts { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.AccountMaster> AccountMasters { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Client> Clients { get; set; }
       // public System.Data.Entity.DbSet<HBShop.Models.Company> Company { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Item> Items { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.OrderDetail> OrderDetails { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.OrderMaster> OrderMaster { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.StockReceived> Stocks { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Supplier> Suppliers { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Country> Countries { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Unit> Units { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Batch> Batches { get; set; }
        
    }
}