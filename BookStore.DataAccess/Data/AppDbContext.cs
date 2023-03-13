using System;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

    }
}

