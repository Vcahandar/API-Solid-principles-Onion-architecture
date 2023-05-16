using DomainLayer.Configurations;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new CountryConfigurations());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                FullName = "Cahandar  Velibeyli",
                Address = "Ehmedli"
            },
            
            new Employee
            {
                Id = 2,
                FullName = "Cavid  Ismayilzade",
                Address = "Ehmedli"
            },
         
            new Employee
            {
                Id = 3,
                FullName = "Arzu  Mamedov",
                Address = "Ehmedli"
            });

            modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "Azerbaijan",
            },

            new Country
            {
                Id = 2,
                Name = "Turkiye",
            },

            new Country
            {
                Id = 3,
                Name = "Ingiltere",
                
            });





        }

    }
}
