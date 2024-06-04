using Microsoft.EntityFrameworkCore;
using SMS.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Persistence.Data
{
    public class EFDataContext: DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options) { }
       
        public DbSet<Student> Students {  get; set; }
      public DbSet<Course> courses { get; set; }
       
    }
}
