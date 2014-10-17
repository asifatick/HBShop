using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HBShop.DAL;
using HBShop.Models;

namespace HBShop.Controllers
{
    public class ItemsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        UnitOfWork uow = new UnitOfWork();
        
        // GET: /Items/
        public ActionResult Index()
        {
            return View(uow.ItemRepo.GetItems().ToList());
        }

        // GET: /Items/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = uow.ItemRepo.GetItemById(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: /Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(uow.CategoryRepo.GetCategories(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: /Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Item item)
        {
            if (ModelState.IsValid)
            {
                item.UpdateDate = DateTime.Now;
                uow.ItemRepo.InsertItem(item);
                uow.Save();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: /Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CategoryId = new SelectList(uow.CategoryRepo.GetCategories(), "CategoryId", "CategoryName");
            Item item = uow.ItemRepo.GetItemById(id.Value);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: /Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                uow.ItemRepo.UpdateItem(item);
                uow.Save();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: /Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = uow.ItemRepo.GetItemById(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: /Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uow.ItemRepo.DeleteItem(id);
            uow.Save();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }    
    }
}
