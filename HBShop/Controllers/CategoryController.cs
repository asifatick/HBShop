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
    public class CategoryController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

        //private ICategoryRepository categoryRepository;

        //public CategoryController()
        //{
        //    this.categoryRepository = new CategoryRepository(new ApplicationDbContext());
        //}

        //public CategoryController(ICategoryRepository categoryRepository)
        //{
        //    this.categoryRepository = categoryRepository;
        //}

        public ViewResult Index()
        {
            var categories = uow.CategoryRepo.GetCategories();
            return View(categories.ToList());
        }

        public ViewResult Details(long categoryId)
        {
            Category category = uow.CategoryRepo.GetCategoryById(categoryId);
            return View(category);
        }
        
        // get
        public ActionResult Create()
        {
            return View(new Category{ });
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category.UpdateDate = DateTime.Now;
                    category.ApplicationUserId = User.Identity.GetUserId();
                    uow.CategoryRepo.InsertCategory(category);
                    uow.CategoryRepo.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }
       
        // GET: /Categories/Edit/5

        public ActionResult Edit(long categoryId)
        {
            Category category = uow.CategoryRepo.GetCategoryById(categoryId);
            return View(category);
            
        }
        
        // POST: /Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(long? categoryId, Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    uow.CategoryRepo.UpdateCategory(category);
                    uow.CategoryRepo.Save();
                }
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View(category);
            }
        }

        ////
                //// GET: /Categories/Delete/5

        public ActionResult Delete(long categoryId)
        {
            Category category = uow.CategoryRepo.GetCategoryById(categoryId);
            return View(category);
        }

        ////
        //// POST: /Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long categoryId)
        {
            try
            {            
                Category category = uow.CategoryRepo.GetCategoryById(categoryId);
                uow.CategoryRepo.DeleteCategory(categoryId);
                uow.CategoryRepo.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            //uow.CategoryRepo.Dispose();
            uow.Dispose();
            base.Dispose(disposing);
        }
    }
}