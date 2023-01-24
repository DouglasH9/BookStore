using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Data;
using BookStoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            if (cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Display order cannot match name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var catFromDb = _db.Categories.FirstOrDefault<Category>(x => x.Id == id);

            if (catFromDb == null)
                return NotFound();


            return View(catFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category cat)
        {
            if (cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and display order cannot be the same.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        //Post
        public IActionResult Delete(int? id)
        {
            var catFromDb = _db.Categories.FirstOrDefault<Category>(x => x.Id == id);

            if (catFromDb is not null)
            {
                _db.Categories.Remove(catFromDb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return NotFound();
            //return View();
        }
    }
}