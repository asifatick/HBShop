using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Purchases_Products
    {
        public long ID { get; set; }
        public virtual Code code { get; set; }
        public double UnitPrice { get; set; }
        public long Quantity { get; set; }
        public double SalesPrice { get; set; }
        public DateTime ExpireDate { get; set; }
        public virtual Supplier supplier { get; set; }
        public string Storage { get; set; }
        public DateTime Purchasesdate { get; set; }
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}