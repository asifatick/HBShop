using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class AccountMaster
    {
        public int AccountMasterId { get; set; }
       
        public double Debit { get; set; }
        public double Credit { get; set; }
        public DateTime DateTime { get; set; }
       
        public virtual AccountMaster  UserId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}