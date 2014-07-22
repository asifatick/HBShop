using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Accounts
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public float Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; }
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}