using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesContext _context;

        public EmployeeRepository(EmployeesContext context)
        {
            _context = context;
        }

        public Employee Create(Employee entity)
        {
            var employee = _context.Employees.Add(entity);
            this._context.SaveChanges();
            return employee.Entity;
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetById(int id)
        {
            var result = _context.Employees.FirstOrDefault(e => e.EmployeeNumber == id);
            return result;
        }

        public Employee Update(int id, Employee entity)
        {
            _context.Employees.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
