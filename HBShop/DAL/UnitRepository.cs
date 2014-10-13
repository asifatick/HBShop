using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using HBShop.Models;
using Microsoft.Ajax.Utilities;

namespace HBShop.DAL
{
    
    public interface IUnitRepository : IDisposable
    {
        IEnumerable<Unit> GetUnits();
        Unit GetUnitByID(long Id);
        void InsertUnit(Unit unit);
        void DeleteUnit(long Id);
        void UpdateUnit(Unit unit);
        void Save();
    }
    public class UnitRepository : IUnitRepository, IDisposable
    {
        private ApplicationDbContext context;

        public UnitRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Unit> GetUnits()
        {
            return context.Units.ToList();
        }

        public Unit GetUnitByID(long Id)
        {
            return context.Units.Find(Id);
        }

        public void InsertUnit(Unit unit)
        {
            context.Units.Add(unit);
        }

        public void DeleteUnit(long Id)
        {
            Unit unit = context.Units.Find(Id);
            context.Units.Remove(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            context.Entry(unit).State = EntityState.Modified;

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