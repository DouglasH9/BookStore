using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPracticeWebApp.Data;
using RazorPracticeWebApp.Model;

namespace RazorPracticeWebApp.Pages.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        private readonly AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Categories.FirstOrDefault<Category>(x => x.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Category Name and Display Order can't match.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

