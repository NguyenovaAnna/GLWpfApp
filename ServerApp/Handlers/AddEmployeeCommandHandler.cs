using MediatR;
using ServerApp.Commands;
using ServerApp.Services;
using Shared.Models;

namespace ServerApp.Handlers
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeesData _data;

        public AddEmployeeCommandHandler(IEmployeesData data)
        {
            _data = data;
        }

        public Task<EmployeeDTO> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.AddEmployee(request.employee));
        }
    }
}
