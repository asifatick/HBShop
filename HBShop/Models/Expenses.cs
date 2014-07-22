using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public virtual Accounts account { get; set; }
        public float Amount { get; set; }
        public DateTime DateTime { get; set; }
       
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}