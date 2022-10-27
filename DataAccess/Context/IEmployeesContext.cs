using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public interface IEmployeesContext
    {
        DbSet<Employee> Employee { get; set; }
        DbSet<ContactMethod> ContactMethod { get; set; }
        DbSet<EmployeeContactMethod> EmployeeContactMethod { get; set; }
    }
}