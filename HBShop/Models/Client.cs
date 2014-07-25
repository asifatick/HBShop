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
        public float TotalReceive { get; set; }
        public float TotalPaid { get; set; }
        public float Advance { get; set; }
        public float Due { get; set; }
        public virtual AccountMaster UserId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}