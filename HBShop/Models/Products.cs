using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Products
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductSubCategory ProductSubCategory { get; set; }
        public string Size { get; set; }
        public string Code { get; set; }
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}