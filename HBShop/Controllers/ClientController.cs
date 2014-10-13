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
    public class ClientController : Controller
    {
        private  UnitOfWork uow = new UnitOfWork();
        
        // GET: /Client/
        public ViewResult Index()
        {
            var clients = uow.ClientRepo.GetClients();
            return View(clients.ToList());
        }
        // GET: /Client/Details/5
        public ViewResult Details(long id)
        {
            Client client = uow.ClientRepo.GetClientById(id);
            return View(client);
        }

        //
        // GET: /Client/Create
        public ActionResult Create()
        {
            return View(new Client { });
        }

        //
        // POST: /Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.Date = DateTime.Now;
                    client.UpdateDate = DateTime.Now;
                    uow.ClientRepo.InsertClient(client);
                    uow.ClientRepo.Save();
                    //return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(client);
            }
        }

        //
        // GET: /Client/Edit/5
        public ActionResult Edit(long Id)
        {
            Client client = uow.ClientRepo.GetClientById(Id);
            return View(client);
        }

        //
        // POST: /Client/Edit/5
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   uow.ClientRepo.UpdateClient(client);
                   uow.ClientRepo.Save();
                   
                }
                 return RedirectToAction("Index");
            }
            catch
            {
                return View(client);
            }
        }        
         //GET: /Client/Delete/5
        public ActionResult Delete(long id)
        {
            Client client = uow.ClientRepo.GetClientById(id);
            return View(client);
        }

        //
        // POST: /Client/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletConfirmed(long id)
        {
            try
            {
                Client client = uow.ClientRepo.GetClientById(id);
                uow.ClientRepo.DeleteClient(id);
                uow.ClientRepo.Save();

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
