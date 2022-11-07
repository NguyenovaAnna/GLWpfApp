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
            var employee = new Employee();
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.MiddleName = entity.MiddleName;
            employee.PersonellNumber = entity.PersonellNumber;
            employee.NationalIdNumber = entity.NationalIdNumber;
            employee.PreviousIdNumber = entity.PreviousIdNumber;
            employee.ActivationTime = entity.ActivationTime;
            employee.ExpirationTime = entity.ExpirationTime;
            _context.Employee.Add(employee);
            _context.SaveChanges();

            foreach (var cm in entity.EmployeeContactMethods)
            {
                var newEmployeeContactMethod = new EmployeeContactMethod();
                newEmployeeContactMethod.EmployeeNumber = employee.EmployeeNumber;
                newEmployeeContactMethod.ContactMethodId = cm.ContactMethodId;
                newEmployeeContactMethod.ContactMethodValue = cm.ContactMethodValue;
                _context.EmployeeContactMethod.Add(newEmployeeContactMethod);
            }
            _context.SaveChanges();
            return employee;
        }

        public void Delete(int id)
        {
            var employees = GetAll();
            var employeeToDelete = employees.FirstOrDefault(x => x.EmployeeNumber == id);
            employeeToDelete.EmployeeContactMethods.Clear();
            _context.Employee.Remove(employeeToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employee.Include(x => x.EmployeeContactMethods).ThenInclude(y => y.ContactMethod).ToList();
        }

        public Employee GetById(int id)
        {
            var result = _context.Employee.FirstOrDefault(e => e.EmployeeNumber == id);
            return result;
        }

        public Employee Update(int id, Employee entity)
        {
            var employee = GetById(id);
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

                var employeeContactMethods = _context.EmployeeContactMethod.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();

                var contactMethodsToBeDeleted = employeeContactMethods.Where(x => !entity.EmployeeContactMethods.Any(y => x.ContactMethodId == y.ContactMethodId)).ToList();

                foreach (var cm in contactMethodsToBeDeleted)
                {
                    employee.EmployeeContactMethods.Remove(cm);
                }

                var contactMethodsToBeUpdated = employeeContactMethods.Where(x => entity.EmployeeContactMethods.Any(y => x.ContactMethodId == y.ContactMethodId)).ToList();

                foreach (var cm in contactMethodsToBeUpdated)
                {
                    var contactMethod = entity.EmployeeContactMethods.FirstOrDefault(x => x.ContactMethodId == cm.ContactMethodId);
                    if (contactMethod != null)
                    {
                        cm.ContactMethodValue = contactMethod.ContactMethodValue;
                    }
                }

                var contactMethodsToBeAdded = entity.EmployeeContactMethods.Where(x => !employeeContactMethods.Any(y => x.ContactMethodId == y.ContactMethodId)).ToList();

                foreach (var cm in contactMethodsToBeAdded)
                {
                    var newEmployeeContactMethod = new EmployeeContactMethod();
                    newEmployeeContactMethod.EmployeeNumber = employee.EmployeeNumber;
                    newEmployeeContactMethod.ContactMethodId = cm.ContactMethodId;
                    newEmployeeContactMethod.ContactMethodValue = cm.ContactMethodValue;
                    _context.EmployeeContactMethod.Add(newEmployeeContactMethod);
                }
            }

            _context.SaveChanges();
            return entity;
        }
    }
}
