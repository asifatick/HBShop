using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public virtual int  ClientId { get; set; }
        public DateTime Date { get; set; }
        public float TotalAmount { get; set; }
        public float Received { get; set; }
    }
}