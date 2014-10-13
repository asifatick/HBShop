using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using HBShop.Models;

namespace HBShop.DAL
{
    public interface IBatchRepository : IDisposable
    {
        IEnumerable<Batch> GeBatches();
        Batch GetBatchById(long id);
        void InsertBatch(Batch batch);
        void DeleteBatch(long id);
        void UpdateBatch(Batch batch);
        void Save();
    }
    public class BatchRepository : IBatchRepository, IDisposable
   {
        private ApplicationDbContext context;

        public BatchRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Batch> GeBatches()
        {
            return context.Batches.ToList();
        }
        public Batch GetBatchById(long id)
        {
            return context.Batches.Find(id);
        }
        public void InsertBatch(Batch batch)
        {
            context.Batches.Add(batch);
        }

        public void DeleteBatch(long id)
        {
            Batch batch = context.Batches.Find(id);
            context.Batches.Remove(batch);
        }

        public void UpdateBatch(Batch batch)
        {
           context.Entry(batch).State = EntityState.Modified;
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