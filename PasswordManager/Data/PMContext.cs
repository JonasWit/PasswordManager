using Microsoft.EntityFrameworkCore;
using PasswordManager.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswordManager.Data
{
    public class PMContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={Path.Combine(Definitions.CorePath, Definitions.DBName)}");

        public static void Startup()
        {
            using var context = new PMContext();
            context.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
