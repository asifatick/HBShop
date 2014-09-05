using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HBShop.Models;
using  HBShop.DAL;
using Microsoft.AspNet.Identity;
//using  PagedList;

namespace HBShop.Controllers
{   
    public class CategoryController : Controller
    {

        private ICategoryRepository categoryRepository;

        public CategoryController()
        {
            this.categoryRepository = new CategoryRepository(new ApplicationDbContext());
        }

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            var categories = categoryRepository.GetCategories();
            return View(categories.ToList());

        }

        public ViewResult Details(long CategoryId)
        {
            Category category = categoryRepository.GetCategoryByID(CategoryId);
            return View(category);
        }
        // get
        public ActionResult Create()
        {
            return View(new Category{ });
        }

        //private HBShopContext context = new HBShopContext();

        ////
        //// GET: /Categories/


        //public ViewResult Index()
        //{
        //    return View(context.Categories.Where(c=> c.CategoryId == 2).j ToList());
        //}

        ////
        //// GET: /Categories/Details/5

        //public ViewResult Details(long id)
        //{
        //    Category category = context.Categories.Single(x => x.CategoryId == id);
        //    return View(category);
        //}

        ////
        //// GET: /Categories/Create

        //public ActionResult Create()
        //{
        //    //ViewBag.PossibleApplicationUsers = ApplicationUsers;
        //    return View();
        //} 

        ////
        //// POST: /Categories/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.UpdateDate = DateTime.Now;
                category.ApplicationUserId = User.Identity.GetUserId();
                categoryRepository.InsertCategory(category);
                categoryRepository.Save();
                return RedirectToAction("Index");
            }

            // ViewBag.PossibleApplicationUsers = UserManager.ge context.ApplicationUsers;
            return View(category);
        }

        ////
        //// GET: /Categories/Edit/5

        //public ActionResult Edit(long id)
        //{
        //    Category category = context.Categories.Single(x => x.CategoryId == id);
        //   // ViewBag.PossibleApplicationUsers = context.ApplicationUsers;
        //    return View(category);
        //}

        ////
        //// POST: /Categories/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Entry(category).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //  //  ViewBag.PossibleApplicationUsers = context.ApplicationUsers;
        //    return View(category);
        //}

        ////
        //// GET: /Categories/Delete/5

        //public ActionResult Delete(long id)
        //{
        //    Category category = context.Categories.Single(x => x.CategoryId == id);
        //    return View(category);
        //}

        ////
        //// POST: /Categories/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    Category category = context.Categories.Single(x => x.CategoryId == id);
        //    context.Categories.Remove(category);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing) {
        //        context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}