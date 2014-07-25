﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public virtual Item ItemId { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public virtual AccountMaster UserId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }


    }
}