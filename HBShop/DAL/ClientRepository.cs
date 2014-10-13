using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using HBShop.Models;

namespace HBShop.DAL
{
    public interface IClientRepository : IDisposable
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(long ClientId);
        void InsertClient(Client client);
        void DeleteClient(long ClientId);
        void UpdateClient(Client ClientId);
        void Save();
    }
    public class ClientRepository : IClientRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ClientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Client> GetClients()
        {
            return context.Clients.ToList();
        }
        public Client GetClientById(long ClientId)
        {
            return context.Clients.Find(ClientId);
        }
        public void InsertClient(Client client)
        {
            context.Clients.Add(client);
        }
        public void DeleteClient(long ClientId)
        {
            Client client = context.Clients.Find(ClientId);
            context.Clients.Remove(client);
        }
        public void UpdateClient(Client client)
        {
            context.Entry(client).State = EntityState.Modified;
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

