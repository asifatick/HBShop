using HBShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HBShop.DAL
{
    public interface IOrderMasterRepository : IDisposable
    {
        IEnumerable<OrderMaster> GetOrdersMaster();
        OrderMaster GetOrderMasterByID(long orderMasterId);
        void InsertOrderMaster(OrderMaster orderMaster);
        void DeleteOrderMaster(long orderMasterId);
        void UpdateOrderMaster(OrderMaster orderMaster);
        void Save();
    }
    public class OrderMasterRepository : IOrderMasterRepository, IDisposable
    {
        private ApplicationDbContext context;

        public OrderMasterRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<OrderMaster> GetOrdersMaster()
        {
            return context.OrderMaster.ToList();
        }
        public OrderMaster GetOrderMasterByID(long orderMasterId)
        {
            return context.OrderMaster.Find(orderMasterId);
        }

        public void InsertOrderMaster(OrderMaster orderMaster)
        {
            context.OrderMaster.Add(orderMaster);
        }

        public void DeleteOrderMaster(long orderMasterId)
        {
            OrderMaster orderMaster = context.OrderMaster.Find(orderMasterId);
            context.OrderMaster.Remove(orderMaster);
        }

        public void UpdateOrderMaster(OrderMaster orderMaster)
        {
            context.Entry(orderMaster).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
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