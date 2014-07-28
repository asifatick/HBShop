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
        public string Addressee { get; set; }
        public string PhoneNo { get; set; }
        public string MobilNo { get; set; }
        
        public decimal Advance { get; set; }
        public decimal Due { get; set; }
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}