using HBShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace HBShop.DAL
{
    public interface ISupplierRepository : IDisposable
    {
        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplierByID(long supplierId);
        void InsertSupplier(Supplier supplier);
        void DeleteSupplier(long supplierId);
        void UpdateSupplier(Supplier supplier);
        void Save();
    }
    public class SupplierRepository :  ISupplierRepository, IDisposable
    {
        private ApplicationDbContext context;

        public SupplierRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return context.Suppliers.ToList();
        }
        public Supplier GetSupplierByID(long supplierId)
        {
            return context.Suppliers.Find(supplierId);
        }

        public void InsertSupplier(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
        }
        public void DeleteSupplier(long supplierId)
        {
            Supplier supplier = context.Suppliers.Find(supplierId);
            context.Suppliers.Remove(supplier);
        }

         public void UpdateSupplier(Supplier supplier)
        {
           context.Entry(supplier).State = EntityState.Modified;
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