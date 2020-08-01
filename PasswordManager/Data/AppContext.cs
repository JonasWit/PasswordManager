using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data
{
    class AppContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source=C:\\SWPConfiguration\\SWPDB.db");

        public static void Startup()
        {
            using var context = new AppContext();
            context.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
