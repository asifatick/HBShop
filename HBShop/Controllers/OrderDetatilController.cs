using HBShop.DAL;
using HBShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HBShop.Controllers
{
    public class OrderDetatilController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

        public ViewResult Index()
        {
            var orderDetails = uow.OrderDetailRepo.GetOrderDetails();
            return View(orderDetails.ToList());
        }

        // GET: /Order/Details/5
        public ViewResult Details(long id)
        {
            OrderDetail orderDetatil = uow.OrderDetailRepo.GetOrderDetailById(id);
            return View(orderDetatil);
        }
        // GET: /Order/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(uow.ItemRepo.GetItems(), "ItemId", "ItemName");
            ViewBag.OrderMasterId = new SelectList(uow.OrderMasterRepo.GetOrdersMaster(), "OrderMasterId");
            ViewBag.UnitId = new SelectList(uow.UnitRepo.GetUnits(), "UnitId");
            return View(new OrderDetail{ });
        }

        // POST: /Order/Create
        [HttpPost]
        public ActionResult Create(OrderDetail orderDetail)
        {          
            if (ModelState.IsValid)
            {
                //test
                orderDetail.UpdateDate = DateTime.Now;
                orderDetail.Date = DateTime.Now;
                uow.OrderDetailRepo.InsertOrderDetail(orderDetail);
                uow.OrderDetailRepo.Save();
                return RedirectToAction("Index");
            }
            return View(orderDetail);
        }
        // GET: /Order/Edit/5
        public ActionResult Edit(int id)
        {
            OrderDetail orderDetail = uow.OrderDetailRepo.GetOrderDetailById(id);
            return View(orderDetail);
        }

        //
        // POST: /Order/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderDetail orderDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    uow.OrderDetailRepo.UpdateOrderDetail(orderDetail);
                    uow.OrderDetailRepo.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(orderDetail);
            }
        }

        //
        // GET: /Orders/Delete/5
        public ActionResult Delete(int id)
        {
            OrderDetail orderDetail = uow.OrderDetailRepo.GetOrderDetailById(id);
            return View(orderDetail);
        }

        //
        // POST: /Orders/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletConfirmed(int id)
        {
            try
            {
                OrderDetail orderDetail = uow.OrderDetailRepo.GetOrderDetailById(id);
                uow.OrderDetailRepo.DeleteOrderDetail(id);
                uow.OrderDetailRepo.Save();
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