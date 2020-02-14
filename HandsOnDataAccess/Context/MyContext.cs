using HandsOnDataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDataAccess.Context
{
   public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0HNC64M\SQLEXPRESS;Initial Catalog=ItemDB;User ID=sa;Password=pass@word");
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
