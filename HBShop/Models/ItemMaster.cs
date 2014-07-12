using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Item
    {
      
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public int  CategoryId { get; set; }
        public int CurrentStock { get; set; }

        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public long CategoryId { get; set; }
        public String Name { get; set; }

    }
}