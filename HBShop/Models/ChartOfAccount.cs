using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class ChartOfAccount
    {
        public long ChartOfAccountId { get; set; }
        public string Name { get; set; }
       // public string Type { get; set; }
        public virtual ApplicationUser User { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}