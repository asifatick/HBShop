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
        public virtual Category CategoryId { get; set; }
        public virtual AccountMaster UserId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}