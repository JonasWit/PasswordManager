using Microsoft.EntityFrameworkCore;
using PasswordManager.Config;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswordManager.Data
{
    public class PMContext : DbContext
    {
        public DbSet<PasswordRecord> Passwords { get; set; }


        public PMContext(DbContextOptions<PMContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
