using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using MediatR;
using ServerApp.Commands;
using ServerApp.Services;
using Shared.Models;

namespace ServerApp.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeeRepository _employeerepo;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeerepo, IMapper mapper)
        {
            _employeerepo = employeerepo;
            _mapper = mapper;
        }
        public Task<EmployeeDTO> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request.employee);
            var employeeToEdit = _employeerepo.Update(employee.EmployeeNumber, employee);
            var editedEmployee = _mapper.Map<EmployeeDTO>(employeeToEdit);
            return Task.FromResult(editedEmployee);
        }
    }
}
