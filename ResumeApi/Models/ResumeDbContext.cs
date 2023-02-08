using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ResumeApi.Models
{
    public class ResumeDbContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

        }
        public DbSet<City> Cities{ get; set; }
        public DbSet<CompanySector> CompanySectors{ get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Employeer> Employeers{ get; set; }
        public DbSet<EmployeeTitle> EmployeeTitles{ get; set; }
        public DbSet<Experience> Experiences{ get; set; }
        public DbSet<User> Users{ get; set; }
        



    }
}
