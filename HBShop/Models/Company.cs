using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Company
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string ContractParson { get; set; }
        public string Addressee { get; set; }
        public string PhoneNo { get; set; }
        public string MobilNo { get; set; }
        public long UserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}