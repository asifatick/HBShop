using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class OrderMaster
    {
        public int OrderId { get; set; }
        public virtual int  ClientId { get; set; }
        public DateTime Date { get; set; }
        public float TotalAmount { get; set; }
        public float Received { get; set; }
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}