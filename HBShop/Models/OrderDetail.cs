using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class OrderDetail
    {
        public long OrderDetailId { get; set; }
        public long ItemId { get; set; }
        public long OrderMasterId { get; set; }
        public virtual OrderMaster OrderMaster { get; set; }
        public virtual Item Item { get; set; }
        public decimal UnitPrice { get; set; }
        public long UnitId { get; set; }
        public virtual HBShop.Models.Unit Unit { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }


    }
}