using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Stock
    {

        public int StockId { get; set; }
        public virtual Item ItemId { get; set; }
        public int Quantity { get; set; }
        public virtual Supplier SupplierId { get; set; }

        public virtual AccountMaster UserId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}