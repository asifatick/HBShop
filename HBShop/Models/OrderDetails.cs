using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public virtual int ItemId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }


    }
}