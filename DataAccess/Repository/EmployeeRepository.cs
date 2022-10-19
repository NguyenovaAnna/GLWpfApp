using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
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
            var employee = _context.Employee.Add(entity);
            this._context.SaveChanges();
            return employee.Entity;
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            employee.ContactMethods.Clear();
            _context.Employee.Remove(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employee.Include(x => x.ContactMethods).ToList();
        }

        public Employee GetById(int id)
        {
            var result = _context.Employee.FirstOrDefault(e => e.EmployeeNumber == id);
            return result;
        }

        public Employee Update(int id, Employee entity)
        {
            var employees = GetAll();
            var employee = employees.FirstOrDefault(x => x.EmployeeNumber == id);
            if (employee != null)
            {
                employee.FirstName = entity.FirstName;
                employee.LastName = entity.LastName;
                employee.MiddleName = entity.MiddleName;
                employee.PersonellNumber = entity.PersonellNumber;
                employee.NationalIdNumber = entity.NationalIdNumber;
                employee.PreviousIdNumber = entity.PreviousIdNumber;
                employee.ActivationTime = entity.ActivationTime;
                employee.ExpirationTime = entity.ExpirationTime;

                var contactMethodsToBeDeleted = employee.ContactMethods.Where(x => !entity.ContactMethods.Any(y => x.ContactMethodId == y.ContactMethodId)).ToList();

                foreach (var cm in contactMethodsToBeDeleted)
                {
                    employee.ContactMethods.Remove(cm);
                }

                var contactMethodsToBeUpdated = employee.ContactMethods.Where(x => entity.ContactMethods.Any(y => x.ContactMethodId == y.ContactMethodId)).ToList();

                foreach (var cm in contactMethodsToBeUpdated)
                {
                    var contactMethod = employee.ContactMethods.FirstOrDefault(x => x.ContactMethodId == cm.ContactMethodId);
                    if (contactMethod != null)
                    {
                        contactMethod.ContactMethodType = cm.ContactMethodType;
                        contactMethod.ContactMethodValue = cm.ContactMethodValue;
                        contactMethod.IsSelected = cm.IsSelected;
                    }
                }

                var contactMethodsToBeAdded = entity.ContactMethods.Where(x => x.ContactMethodId == 0).ToList();

                foreach (var cm in contactMethodsToBeAdded)
                {
                    employee.ContactMethods.Add(cm);
                }
            }

            _context.SaveChanges();
            return entity;
        }
    }
}
