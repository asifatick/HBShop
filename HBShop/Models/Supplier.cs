using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
        public string ContractParson { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string MobilNo { get; set; }
        public double Deposit { get; set; }
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
        public decimal Advance { get; set; }
        public decimal Due { get; set; }
        public List<Item> Items { get; set; }
        public virtual ApplicationUser User { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}