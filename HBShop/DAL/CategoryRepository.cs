using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using HBShop.Models;

namespace HBShop.DAL
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(long categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(long categoryId);
        void UpdateCategory(Category category);
        void Save();
    }
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public Category GetCategoryById(long categoryId)
        {
            return context.Categories.Find(categoryId);
        }
        public void InsertCategory(Category category)
        {
            context.Categories.Add(category);
        }
        public void DeleteCategory(long categoryId)
        {
            Category category = context.Categories.Find(categoryId);
            context.Categories.Remove(category);
        }
        public void UpdateCategory(Category category)
        {
           context.Entry(category).State = EntityState.Modified;
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