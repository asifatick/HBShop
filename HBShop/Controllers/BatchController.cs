using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HBShop.Models;
using HBShop.DAL;
using Microsoft.AspNet.Identity;

namespace HBShop.Controllers
{
    public class BatchController : Controller
    {

        private UnitOfWork uow = new UnitOfWork();

        public ViewResult Index()
        {
            var batches = uow.BatchRepository.GeBatches();
            return View(batches.ToList());
        }
        //test
        // GET: /Batch/Details/5
        public ViewResult Details(int id)
        {
            Batch batch = uow.BatchRepository.GetBatchById(id);
            return View(batch);
        }

        //
        // GET: /Batch/Create
        public ActionResult Create()
        {
            return View(new Batch{});
        }

        // POST: /Batch/Create
        [HttpPost]
        public ActionResult Create(Batch batch)
        {
            if (ModelState.IsValid)
            {                
                batch.Date = DateTime.Now;
                batch.UpdateDate = DateTime.Now;
                uow.BatchRepository.InsertBatch(batch);
                uow.BatchRepository.Save();
                return RedirectToAction("Index");
            }
            return View(batch);
        }

        // GET: /Batch/Edit/5
        public ActionResult Edit(int id)
        {
            Batch batch = uow.BatchRepository.GetBatchById(id);
            return View(batch);
        }

        //
        // POST: /Batch/Edit/5
        [HttpPost]
        public ActionResult Edit(Batch batch)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     uow.BatchRepository.UpdateBatch(batch);
                     uow.BatchRepository.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(batch);
            }
        }

        //
        // GET: /Batch/Delete/5
        public ActionResult Delete(int id)
        {
            Batch batch = uow.BatchRepository.GetBatchById(id);
            return View(batch);
        }

        //
        // POST: /Batch/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletConfirmed(int id)
        {
            try
            {
                Batch batch = uow.BatchRepository.GetBatchById(id);
                uow.BatchRepository.DeleteBatch(id);
                uow.BatchRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            uow.Dispose();
            base.Dispose(disposing);
        }
    }
}
