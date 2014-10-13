using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Batch
    {
        public long Id { get; set; }
        public string BatchName { get; set; }
        public DateTime Date { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}