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
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        public virtual Supplier Supplier { get; set; }
        public string Batch { get; set; }
        public decimal CostPerUnit { get; set; }
        public virtual Unit  Unit{ get; set; }
        public DateTime Date { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}