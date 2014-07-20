using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Sales
    {
        public long ID { get; set; }
        public virtual Code code { get; set; }
        public int Quantity { get; set; }
    }
}