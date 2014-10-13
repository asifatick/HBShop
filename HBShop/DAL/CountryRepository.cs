using HBShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HBShop.DAL
{
    public interface ICountryRepository : IDisposable
    {
        IEnumerable<Country> GetCountries();
        Country GetCountryByID(long countryId);
        void InsertCountry(Country country);
        void DeleteCountry(long countryId);
        void UpdateCountry(Country country);
        void Save();

    }

    public class CountryRepository : ICountryRepository, IDisposable
    {
        private ApplicationDbContext context;

        public CountryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Country> GetCountries()
        {
            return context.Countries.ToList();
        }

        public Country GetCountryByID(long countryId)
        {
            return context.Countries.Find(countryId);
        }

        public void InsertCountry(Country country)
        {
            context.Countries.Add(country);
        }

        public void DeleteCountry(long countryId)
        {
            Country country = context.Countries.Find(CountryId);
            context.Countries.Remove(country);
        }

        public void UpdateCountry(Country country)
        {
            context.Entry(country).State = EntityState.Modified;
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

        public object[] CountryId { get; set; }
    }
}


