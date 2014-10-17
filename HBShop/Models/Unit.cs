using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBShop.Models
{
    public class Unit
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual ApplicationUser User { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
