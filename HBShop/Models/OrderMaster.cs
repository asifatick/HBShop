using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace HBShop.Models
{
    public class OrderMaster
    {
        public long OrderMasterId { get; set; }
        public  long  ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime Date { get; set; }
        public float TotalAmount { get; set; }
        public float Received { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> Details { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public enum OrderStatus
        {
            Ordered =0,
            Paid,
            Delivered,
            Shipped
        }
    }
}