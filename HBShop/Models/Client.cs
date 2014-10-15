using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Client
    {
        public long ClientId { get; set; }
        public string ClientName { get; set; }
        public string Addresse { get; set; }
        public string PhoneNo { get; set; }
        public string MobilNo { get; set; }        
        public decimal Advance { get; set; }
        public decimal Due { get; set; }      
        public virtual Country Country { get; set; }
        public DateTime Date { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}