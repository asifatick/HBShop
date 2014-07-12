using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class StockReceive
    {
        public virtual int  ItemId { get; set; }
        public DateTime EntryDate { get; set; }
        public int EntryQuantity { get; set; }
        public string From { get; set; }
        public int ReceiptNo { get; set; }

    }
}