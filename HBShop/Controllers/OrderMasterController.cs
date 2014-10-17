using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HBShop.DAL;
using HBShop.Models;

namespace HBShop.Controllers
{
    public class OrderMasterController : Controller
    {
        //UnitOfWork uow = new UnitOfWork();
        // GET: /OrderMaster/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /OrderMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /OrderMaster/Create
        public ActionResult Create()
        {
            //ViewBag.OrderMasterId = new SelectList(uow.OrderMasterRepo.GetOrdersMaster(), "OrderMasterId");
            return View();
        }

        //
        // POST: /OrderMaster/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OrderMaster/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /OrderMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OrderMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /OrderMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
