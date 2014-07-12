using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public float Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string CreateBy { get; set; }
        public string Type { get; set; }

    }
}