using Microsoft.EntityFrameworkCore;
using SMS.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Persistence.Data
{
    public class InMemoryDataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}
