using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class AccountMaster
    {
        public long AccountMasterId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime DateTime { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}