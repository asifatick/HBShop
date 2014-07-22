using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HBShop.Models.Accounts> Accounts { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.AccountMasters> AccountMasters { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Categorys> Categorys { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Clients> Clients { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Company> Company { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Expenses> Expenses { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Items> Items { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.OrderDetails> OrderDetails { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.OrderMaster> OrderMaster { get; set; }

        public System.Data.Entity.DbSet<HBShop.Models.Stocks> Stocks { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.Supplier> Supplier { get; set; }
       
        
    }
}