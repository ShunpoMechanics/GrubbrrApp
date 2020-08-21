using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrubbrrApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GrubbrrApp.DAL
{
    public class EmployeeContext : DbContext
    {
        private static string connectionString = "Server=localhost;Database=MVCApp;Trusted_Connection=True;";

        public EmployeeContext() : base("DatabaseContext")
        {

        }

        public DbSet<Employee> Employees { get; set;}
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        
    }
}