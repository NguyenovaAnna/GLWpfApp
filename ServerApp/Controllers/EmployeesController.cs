using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
using ServerApp.Services;
using MediatR;
using ServerApp.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ISender _mediator;

        public EmployeesController(ISender mediator)
        {
            _mediator = mediator;
        }


        //private EmployeesData _employeesData;

        //public EmployeesController(Services.EmployeesData employeesData)
        //{
        //    _employeesData = employeesData;
        //}

        // GET: api/employees
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emps = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(emps);
        }
        //public List<EmployeeDTO> Get()
        //{
        //    return _employeesData.employees;
        //}

        // POST api/employees
        [HttpPost]
        public void Post(EmployeeDTO employee)
        {
            //_employeesData.employees.Add(employee);
        }
        
        // PUT api/employees/5
        [HttpPut("{id}")]
        public void Put(int id, EmployeeDTO employee)
        {
            //var emp = _employeesData.employees.Where(x => x.EmployeeNumber == id).FirstOrDefault();
            //if (emp != null)
            //{
            //    emp.FirstName = employee.FirstName;
            //    emp.LastName = employee.LastName;
            //    emp.EmployeeNumber = employee.EmployeeNumber;
            //    emp.MiddleName = employee.MiddleName;
            //    emp.NationalIdNumber = employee.NationalIdNumber;
            //    emp.PreviousIdNumber = employee.PreviousIdNumber;
            //    emp.PersonellNumber = employee.PersonellNumber;
            //    emp.ActivationTime = employee.ActivationTime;
            //    emp.ExpirationTime = employee.ExpirationTime;
            //    emp.ContactMethods = employee.ContactMethods;
            //}
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var emp = _employeesData.employees.Where(x => x.EmployeeNumber == id).FirstOrDefault();
            //if (emp != null)
            //{
            //    _employeesData.employees.Remove(emp);
            //}
        }
    }
}
