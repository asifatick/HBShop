using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HBShop.Controllers;
using HBShop.Models;

namespace HBShop.DAL
{
    public interface IItemRepository : IDisposable
    {
        IEnumerable<Item> GetItems();
        Item GetItemById(long itemId);
        void InsertItem(Item item);
        void DeleteItem(long itemId);
        void UpdateItem(Item item);
        void Save();
    }
    public class ItemRepository : IItemRepository,IDisposable
    {
        private ApplicationDbContext context;

        public ItemRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Item> GetItems()
        {
            return context.Items.ToList();
        }
        public Item GetItemById(long itemId)
        {
            return context.Items.Find(itemId);
        }
        public void InsertItem(Item item)
        {
            context.Items.Add(item);
        }

        public void DeleteItem(long itemId)
        {
            Item item = context.Items.Find(itemId);
            context.Items.Remove(item);
        }
        public void UpdateItem(Item item)
        {
            context.Entry(item).State = EntityState.Modified;
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