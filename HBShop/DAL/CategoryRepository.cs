using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HBShop.Models;

namespace HBShop.DAL
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryByID(long categoryId);
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryByID(long categoryId)
        {
            throw new NotImplementedException();
        }

        public void InsertCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(long categoryId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}