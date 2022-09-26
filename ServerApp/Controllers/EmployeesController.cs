using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Net;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static EmployeesData employeesData = EmployeesData.GetEmployeesData();
   
        // GET: api/employees
        [HttpGet]
        public List<EmployeeDTO> Get()
        {
            return employeesData.employees;
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public EmployeeDTO Get(int id)
        {
            return employeesData.employees.Where(x => x.EmployeeNumber == id).FirstOrDefault();
        }

        // POST api/employees
        [HttpPost]
        public void Post(EmployeeDTO employee)
        {
            employeesData.employees.Add(employee);
        }
        
        // PUT api/employees/5
        [HttpPut("{id}")]
        public void Put(int id, EmployeeDTO employee)
        {
            var emp = employeesData.employees.Where(x => x.EmployeeNumber == id).FirstOrDefault();
            if (emp != null)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.EmployeeNumber = employee.EmployeeNumber;
                emp.MiddleName = employee.MiddleName;
                emp.NationalIdNumber = employee.NationalIdNumber;
                emp.PreviousIdNumber = employee.PreviousIdNumber;
                emp.PersonellNumber = employee.PersonellNumber;
                emp.ActivationTime = employee.ActivationTime;
                emp.ExpirationTime = employee.ExpirationTime;
                emp.ContactMethods = employee.ContactMethods;
            }
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var emp = employeesData.employees.Where(x => x.EmployeeNumber == id).FirstOrDefault();
            if (emp != null)
            {
                employeesData.employees.Remove(emp);
            }
        }
    }
}
