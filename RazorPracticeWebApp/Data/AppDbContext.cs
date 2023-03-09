using System;
using RazorPracticeWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace RazorPracticeWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}

