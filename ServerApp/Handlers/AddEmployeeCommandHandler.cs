using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using ServerApp.Commands;
using ServerApp.Services;
using Shared.Models;

namespace ServerApp.Handlers
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeeRepository _employeerepo;
        private readonly IMapper _mapper;

        public AddEmployeeCommandHandler(IEmployeeRepository employeerepo, IMapper mapper)
        {
            _employeerepo = employeerepo;
            _mapper = mapper;
        }

        public Task<EmployeeDTO> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request.employee);
            var newEmployee = _employeerepo.Create(employee);
            var createdEmployee = _mapper.Map<EmployeeDTO>(newEmployee);
            return Task.FromResult(createdEmployee);

            //return Task.FromResult(_data.AddEmployee(request.employee));
        }
    }
}
