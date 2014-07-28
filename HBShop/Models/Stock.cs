using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HBShop.Models
{
    public class StockReceived
    {

        public long StockReceivedId { get; set; }
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        public long SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public string BatchNo { get; set; }
        public decimal CostPerUnit { get; set; }
        public long UnitId { get; set; }
        public virtual HBShop.Models.Unit Unit { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}