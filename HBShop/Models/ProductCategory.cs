﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class ProductCategory
    {
      
        public long ID { get; set; }
        public String Name { get; set; }
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}