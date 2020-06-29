using EmployeeAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeAPI.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\\MyLocalDB;Initial Catalog=Studentdb;Integrated Security=True;");
            }
            
        }
    }
}
