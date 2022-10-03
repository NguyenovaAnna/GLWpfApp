using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
using ServerApp.Services;
using MediatR;
using ServerApp.Queries;
using ServerApp.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<List<EmployeeDTO>> GetAll()
        {
            var emps = await _mediator.Send(new GetAllEmployeesQuery());
            return emps;
        }

        // POST api/employees
        [HttpPost]
        public async Task<EmployeeDTO> Post(EmployeeDTO employee)
        {
            var emp = new AddEmployeeCommand(employee);
            return await _mediator.Send(emp);
        }
        
        // PUT api/employees/5
        [HttpPut("{id}")]
        public async Task<EmployeeDTO> Put(int id, EmployeeDTO employee)
        {
            var emp = new UpdateEmployeeCommand(id, employee);
            return await _mediator.Send(emp);
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var emp = new RemoveEmployeeCommand(id);
            await _mediator.Send(emp);
        }
    }
}
