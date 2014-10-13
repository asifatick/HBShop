using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HBShop.DAL;
using HBShop.Models;

namespace HBShop.Controllers
{
    public class UnitController : Controller
    {
        private IUnitRepository unitRepository;

        public UnitController()
        {
            this.unitRepository = new UnitRepository(new ApplicationDbContext());
        }

        public UnitController(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }

        //
        // GET: /Unit/
        public ViewResult Index()
        {
            var units = unitRepository.GetUnits();
            return View(units.ToList());
        }

        //
        // GET: /Unit/Details/5
        public ViewResult Details(int id)
        {
            Unit unit = unitRepository.GetUnitByID(id);
            return View(unit);
        }

        //
        // GET: /Unit/Create
        public ActionResult Create()
        {
            return View(new Unit{});
        }

        //
        // POST: /Unit/Create
        [HttpPost]
        public ActionResult Create(Unit unit)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    unitRepository.InsertUnit(unit);
                    unitRepository.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(unit);
            }
        }

        //
        // GET: /Unit/Edit/5
        public ActionResult Edit(int id)
        {
            Unit unit = unitRepository.GetUnitByID(id);

            return View(unit);
        }

        //
        // POST: /Unit/Edit/5
        [HttpPost]
        public ActionResult Edit(Unit unit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitRepository.UpdateUnit(unit);
                    unitRepository.Save();
                    return RedirectToAction("Index");
                }
                return View(unit);

            }
            catch
            {
                return View(unit);
            }
        }

        //
        // GET: /Unit/Delete/5
        public ActionResult Delete(int id)
        {
            Unit unit = unitRepository.GetUnitByID(id);
            return View(unit);
        }

        //
        // POST: /Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Unit unit = unitRepository.GetUnitByID(id);
                unitRepository.DeleteUnit(id);
                unitRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

            
        }

        protected override void Dispose(bool disposing)
        {
            unitRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
