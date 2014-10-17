using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using  System.Data;
using HBShop.Models;

namespace HBShop.DAL
{
    public interface IAccountMasterRepository : IDisposable
    {
        IEnumerable<AccountMaster> GetAccountsMaster();
        AccountMaster GetAccountMasterByID(long accountMasterId);
        void InsertAccountMaster(AccountMaster accountMaster);
        void DeleteAccountMaster(long accountMasterId);
        void UpdateAccountMaster(AccountMaster accountMaster);
        void Save();

    }

    public class AccountMasterRepository : IAccountMasterRepository, IDisposable
    {
        private ApplicationDbContext context;

        public AccountMasterRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<AccountMaster> GetAccountsMaster()
        {
            return context.AccountMasters.ToList();
        }

        public AccountMaster GetAccountMasterByID(long accountMasterId)
        {
            return context.AccountMasters.Find(accountMasterId);
        }

        public void InsertAccountMaster(AccountMaster accountMaster)
        {
            context.AccountMasters.Add(accountMaster);
        }

        public void DeleteAccountMaster(long accountMasterId)
        {
            AccountMaster accountMaster = context.AccountMasters.Find(accountMasterId);
            context.AccountMasters.Remove(accountMaster);
        }

        public void UpdateAccountMaster(AccountMaster accountsMaster)
        {
            context.Entry(accountsMaster).State = EntityState.Modified;

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