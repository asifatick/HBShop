using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Stocks
    {
        public int OrderId { get; set; }
        public virtual Items item { get; set; }
        public int Quantity { get; set; }
        public virtual Supplier supplier { get; set; }
        public virtual OrderMaster order { get; set; }
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}