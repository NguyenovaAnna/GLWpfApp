using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class EmployeesContext : DbContext, IEmployeesContext
    {

        public EmployeesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<ContactMethod> ContactMethod { get; set; }
        //public DbSet<EmployeeContactMethod> EmployeeContactMethod { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<EmployeeContactMethod>()
            //    .HasKey(ecm => new { ecm.EmployeeNumber, ecm.ContactMethodId });
            //builder.Entity<EmployeeContactMethod>()
            //    .HasOne(ecm => ecm.Employee)
            //    .WithMany(ecm => ecm.ContactMethods)
            //    .HasForeignKey(ecm => ecm.ContactMethodId);
            //builder.Entity<EmployeeContactMethod>()
            //    .HasOne(ecm => ecm.ContactMethod)
            //    .WithMany(ecm => ecm.Employees)
            //    .HasForeignKey(ecm => ecm.EmployeeNumber); -> toto je stare a zle


            //builder.Entity<Employee>()
            //    .HasMany(x => x.ContactMethods)
            //    .WithMany(x => x.Employees)
            //    .UsingEntity<EmployeeContactMethod>(
            //        x => x.HasOne(x => x.ContactMethod)
            //        .WithMany().HasForeignKey(x => x.ContactMethodId),
            //        x => x.HasOne(x => x.Employee)
            //        .WithMany().HasForeignKey(x => x.EmployeeNumber));

            //builder.Entity<EmployeeContactMethod>()
            //    .HasKey(x => new { x.EmployeeNumber, x.ContactMethodId});


        }

    }
}
