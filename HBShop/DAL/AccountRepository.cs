//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using HBShop.Models;

//namespace HBShop.DAL
//{
//    public interface IAccountRepository : IDisposable
//    {
//        IEnumerable<Account> GetAccounts();
//        Country GetAccountByID(long accountId);
//        void InsertAccount(Account account);
//        void DeleteAccount(long accountId);
//        void UpdateAccount(Account account);
//        void Save();

//    }
//    public class AccountRepository
//    {
//        private ApplicationDbContext context;

//        public AccountRepository(ApplicationDbContext context)
//        {
//            this.context = context;
//        }
//        public IEnumerable<Account> GetCountries()
//        {
//            return context.Accounts.ToList();
//        }

//        public Country GetAccountByID(long accountId)
//        {
//            return context.Countries.Find(accountId);
//        }

//        public void InsertCountry(Account country)
//        {
//            context.Countries.Add(country);
//        }

//        public void DeleteAccount(long accountId)
//        {
//            Account account = context.Accounts.Find(AccountId);
//            context.Accounts.Remove(account);
//        }

//        public void UpdateCountry(Account account)
//        {
//            context.Entry(account).State = EntityState.Modified;
//        }

//        public void Save()
//        {
//            context.SaveChanges();
//        }

//        private bool disposed = false;

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    context.Dispose();
//                }
//            }
//            this.disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        public object[] AccountId { get; set; }
//    }
//}

//    }
//}