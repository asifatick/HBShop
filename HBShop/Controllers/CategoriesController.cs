using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HBShop.Models;
using Microsoft.AspNet.Identity;

namespace HBShop.Controllers
{   
    public class CategoriesController : Controller
    {
        private HBShopContext context = new HBShopContext();

        //
        // GET: /Categories/

       
        public ViewResult Index()
        {
            return View(context.Categories.ToList());
        }

        //
        // GET: /Categories/Details/5

        public ViewResult Details(long id)
        {
            Category category = context.Categories.Single(x => x.CategoryId == id);
            return View(category);
        }

        //
        // GET: /Categories/Create

        public ActionResult Create()
        {
            //ViewBag.PossibleApplicationUsers = ApplicationUsers;
            return View();
        } 

        //
        // POST: /Categories/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

           // ViewBag.PossibleApplicationUsers = UserManager.ge context.ApplicationUsers;
            return View(category);
        }
        
        //
        // GET: /Categories/Edit/5
 
        public ActionResult Edit(long id)
        {
            Category category = context.Categories.Single(x => x.CategoryId == id);
           // ViewBag.PossibleApplicationUsers = context.ApplicationUsers;
            return View(category);
        }

        //
        // POST: /Categories/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
          //  ViewBag.PossibleApplicationUsers = context.ApplicationUsers;
            return View(category);
        }

        //
        // GET: /Categories/Delete/5
 
        public ActionResult Delete(long id)
        {
            Category category = context.Categories.Single(x => x.CategoryId == id);
            return View(category);
        }

        //
        // POST: /Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Category category = context.Categories.Single(x => x.CategoryId == id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}