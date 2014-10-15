using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Item
    {
        public long ItemId { get; set; }
        public String ItemName { get; set; }
        public String Size { get; set; }
        public String ItemCode { get; set; }
        public int ReorderLevel { get; set; }
        public int StockInHand { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}