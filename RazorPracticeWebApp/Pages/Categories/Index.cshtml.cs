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
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Categories;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            Category cat = _db.Categories.FirstOrDefault<Category>(x => x.Id == id);

            if (cat is not null)
            {
                _db.Categories.Remove(cat);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            Console.WriteLine("Nulllllllllll");
            return Page();
        }
    }
}
