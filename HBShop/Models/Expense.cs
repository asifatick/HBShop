using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public virtual Account AccountId { get; set; }
        public float Amount { get; set; }
        public DateTime DateTime { get; set; }

        public virtual AccountMaster UserId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}