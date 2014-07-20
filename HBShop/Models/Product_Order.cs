using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Product_Order
    {
        public long ID { get; set; }
        public virtual Code code { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public virtual Supplier supplier { get; set; }
        public DateTime Purchasesdate { get; set; }
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}