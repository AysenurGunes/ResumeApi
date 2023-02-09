using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ResumeApi.Models
{
    public class ResumeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ResumeDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (_environmentSelect.IsDevelopment)
            //{
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DevCon"));
           // }
            //else
            //{
            //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProdCon"));
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(c => c.UserID).IsRequired();
            modelBuilder.Entity<User>().HasKey(c => c.UserID).IsClustered();

            modelBuilder.Entity<City>().Property(c => c.CityID).IsRequired();
            modelBuilder.Entity<City>().HasKey(c => c.CityID).IsClustered();

            modelBuilder.Entity<CompanySector>().Property(c => c.CompanySectorID).IsRequired();
            modelBuilder.Entity<CompanySector>().HasKey(c => c.CompanySectorID).IsClustered();

            modelBuilder.Entity<Country>().Property(c => c.CountryID).IsRequired();
            modelBuilder.Entity<Country>().HasKey(c => c.CountryID).IsClustered();

            modelBuilder.Entity<Employee>().Property(c => c.EmployeeID).IsRequired();
            modelBuilder.Entity<Employee>().HasKey(c => c.EmployeeID).IsClustered();

            modelBuilder.Entity<Employeer>().Property(c => c.EmployeerID).IsRequired();
            modelBuilder.Entity<Employeer>().HasKey(c => c.EmployeerID).IsClustered();

            modelBuilder.Entity<EmployeeTitle>().Property(c => c.EmployeeTitleID).IsRequired();
            modelBuilder.Entity<EmployeeTitle>().HasKey(c => c.EmployeeTitleID).IsClustered();

            modelBuilder.Entity<Experience>().Property(c => c.ExperienceID).IsRequired();
            modelBuilder.Entity<Experience>().HasKey(c => c.ExperienceID).IsClustered();


        }
        public DbSet<City> Cities { get; set; }
        public DbSet<CompanySector> CompanySectors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employeer> Employeers { get; set; }
        public DbSet<EmployeeTitle> EmployeeTitles { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<User> Users { get; set; }




    }
}
