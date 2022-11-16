using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
using MediatR;
using ServerApp.Queries;
using ServerApp.Commands;
using DataAccess.Entities;
using ServerApp.Queries.EmployeeQueries;
using ServerApp.Queries.ContactMethodQueries;
using ServerApp.RabbitMQ;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IRabbitMQProducer _messageProducer;

        public EmployeesController(IMediator mediator, IRabbitMQProducer messageProducer)
        {
            _mediator = mediator;
            _messageProducer = messageProducer;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<List<EmployeeDTO>> GetAll()
        {
            var emps = await _mediator.Send(new GetAllEmployeesQuery());
            _messageProducer.SendMessage(emps);
            return emps;
        }

        // POST: api/employees
        [HttpPost]
        public async Task<EmployeeDTO> Post(EmployeeDTO employee)
        {
            var emp = new AddEmployeeCommand(employee);
            return await _mediator.Send(emp);
        }
        
        // PUT: api/employees/5
        [HttpPut("{id}")]
        public async Task<EmployeeDTO> Put(int id, EmployeeDTO employee)
        {
            var emp = new UpdateEmployeeCommand(id, employee);
            return await _mediator.Send(emp);
        }

        // DELETE: api/employees/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var emp = new RemoveEmployeeCommand(id);
            await _mediator.Send(emp);
        }

        //GET: api/employees/contactmethods
        [HttpGet("contactMethods")]
        public async Task<List<ContactMethodTypesDTO>> GetAllContactMethods()
        {
            var cms = await _mediator.Send(new GetAllContactMethodsQuery());
            return cms;
        }
    }
}
