using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBShop.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public float TotalReceive { get; set; }
        public float TotalPaid { get; set; }
        public float Advance { get; set; }
        public float Due { get; set; }

    }
}