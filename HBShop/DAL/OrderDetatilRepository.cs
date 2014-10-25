using HBShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;

namespace HBShop.DAL
{
    public interface IOrderDetailRepository : IDisposable
    {
        IEnumerable<OrderDetail> GetOrderDetails();
        IEnumerable<OrderDetail> GetOrderDetailsByOrderId(long orderId);
        OrderDetail GetOrderDetailById(long id);
        void InsertOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(long id);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void Save();
    }
    public class OrderDetailRepository : IOrderDetailRepository, IDisposable
    {
        private ApplicationDbContext context;

        public OrderDetailRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return context.OrderDetails.ToList();
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(long orderId)
        {
            return context.OrderDetails.Where(x => x.OrderMasterId == orderId).ToList();
        }

        public OrderDetail GetOrderDetailById(long id)
        {
            return context.OrderDetails.Find(id);
        }
        public void InsertOrderDetail(OrderDetail orderDetail)
        {
            context.OrderDetails.Add(orderDetail);
        }

        public void DeleteOrderDetail(long id)
        {
            OrderDetail orderDetail = context.OrderDetails.Find(id);
            context.OrderDetails.Remove(orderDetail);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
           context.Entry(orderDetail).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (! this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
    }
}