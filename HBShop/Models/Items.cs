using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Items
    {
        public long ID { get; set; }
        public String ItemName { get; set; }
        public String Size { get; set; }
        public String ItemCode { get; set; }
        public virtual Categorys category { get; set; }
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}