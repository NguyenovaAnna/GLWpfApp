using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public interface IEmployeesContext
    {
        DbSet<Employee> Employees { get; set; }
    }
}