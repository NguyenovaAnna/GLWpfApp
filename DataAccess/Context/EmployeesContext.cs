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
        public DbSet<EmployeeContactMethod> EmployeeContactMethod { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeeContactMethod>()
                .HasKey(ecm => new { ecm.EmployeeNumber, ecm.ContactMethodId });
            builder.Entity<EmployeeContactMethod>()
                .HasOne(ecm => ecm.Employee)
                .WithMany(ecm => ecm.EmployeeContactMethods)
                .HasForeignKey(ecm => ecm.EmployeeNumber);
            builder.Entity<EmployeeContactMethod>()
                .HasOne(ecm => ecm.ContactMethod)
                .WithMany(ecm => ecm.Employees)
                .HasForeignKey(ecm => ecm.ContactMethodId);

            //disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
