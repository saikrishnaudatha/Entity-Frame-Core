using HandsOnEFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnEFCodeFirst.Context
{
    class MyContext:DbContext
    {
        public DbSet<Student>Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0HNC64M\SQLEXPRESS;Initial Catalog=StudentDB;User ID=sa;Password=pass@word");
        }
    }
}
