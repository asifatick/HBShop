using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using HBShop.Models;

namespace HBShop.DAL
{
    public interface IStockReceivedRepository : IDisposable
    {
        IEnumerable<StockReceived> GetStocks();
        StockReceived GetStockReceivedById(long stockReceivedId);
        void InsertStockReceived(StockReceived stockReceived);
        void DeleteStockReceived(long stockReceivedId);
        void UpdateStockReceived(StockReceived stockReceivedId);
        void Save();
    }

    public class StockReceivedRepository : IStockReceivedRepository, IDisposable
    {
        private ApplicationDbContext context;

        public StockReceivedRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

       
        public IEnumerable<StockReceived> GetStocks()
        {
            return context.Stocks.ToList();
        }

        public StockReceived GetStockReceivedById(long stockReceivedId)
        {
            return context.Stocks.Find(stockReceivedId);
        }

        public void InsertStockReceived(StockReceived stockReceived)
        {
            context.Stocks.Add(stockReceived);
        }

        public void DeleteStockReceived(long stockReceivedId)
        {
            StockReceived stockReceived = context.Stocks.Find(stockReceivedId);
            context.Stocks.Remove(stockReceived);
        }

        public void UpdateStockReceived(StockReceived StockReceived)
        {
           context.Entry(StockReceived).State = EntityState.Modified;
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