using System;
using BookStoreWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

    }
}

