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
        private UnitOfWork uow = new UnitOfWork();
        // GET: /OrderMaster/

        public ActionResult Index()
        {
            var orderMaster = uow.OrderMasterRepo.GetOrdersMaster();
            return View(orderMaster.ToList());
        }

        //
        // GET: /OrderMaster/Details/5
        public ActionResult Details(int id)
        {
            OrderMaster orderMaster = uow.OrderMasterRepo.GetOrderMasterById(id);
            return View(orderMaster);
        }

        //
        // GET: /OrderMaster/Create
        public ActionResult Create()
        {
            //ViewBag.Status = new SelectList(uow.OrderMasterRepo.GetOrdersMaster(), "Order Status");
            ViewBag.ClientId = new SelectList(uow.ClientRepo.GetClients(), "ClientId", "ClientName");
            return View(new OrderMaster { });
        }

        //
        // POST: /OrderMaster/Create
        [HttpPost]
        public ActionResult Create(OrderMaster orderMaster)
        {
            if (ModelState.IsValid)
            {
                //test
                orderMaster.UpdateDate = DateTime.Now;
                orderMaster.Date = DateTime.Now;
                uow.OrderMasterRepo.InsertOrderMaster(orderMaster);
                uow.OrderMasterRepo.Save();
                return RedirectToAction("Index");
            }
            return View(orderMaster);
        }

        //
        // GET: /OrderMaster/Edit/5
        public ActionResult Edit(int id)
        {
            OrderMaster orderMaster = uow.OrderMasterRepo.GetOrderMasterById(id);
            return View(orderMaster);
        }

        //
        // POST: /OrderMaster/Edit/5
        [HttpPost]
        public ActionResult Edit( OrderMaster orderMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    uow.OrderMasterRepo.UpdateOrderMaster(orderMaster);
                    uow.OrderMasterRepo.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(orderMaster);
            }
        }

        //
        // GET: /OrderMaster/Delete/5
        public ActionResult Delete(int id)
        {
            OrderMaster orderMaster = uow.OrderMasterRepo.GetOrderMasterById(id);
            return View(orderMaster);
        }

        //
        // POST: /OrderMaster/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletConfirmed(int id)
        {
            try
            {
                OrderMaster orderMaster = uow.OrderMasterRepo.GetOrderMasterById(id);
                uow.OrderMasterRepo.DeleteOrderMaster(id);
                uow.OrderMasterRepo.Save();
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
