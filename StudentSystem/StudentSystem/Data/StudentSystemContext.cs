using Microsoft.EntityFrameworkCore;
using StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {

        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
           : base(options)
        {

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
