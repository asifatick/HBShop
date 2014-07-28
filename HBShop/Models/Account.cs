using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Account
    {
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}