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

        public System.Data.Entity.DbSet<HBShop.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<HBShop.Models.Item> Items { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.ProductCategory> ProductCategory { get; set; }
        public System.Data.Entity.DbSet<HBShop.Models.ProductSubCategory> ProductSubCategory { get; set; }
        
    }
}