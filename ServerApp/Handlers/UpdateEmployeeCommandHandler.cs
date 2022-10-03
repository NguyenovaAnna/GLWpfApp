using MediatR;
using ServerApp.Commands;
using ServerApp.Services;
using Shared.Models;

namespace ServerApp.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeesData _data;

        public UpdateEmployeeCommandHandler(IEmployeesData data)
        {
            _data = data;
        }
        public Task<EmployeeDTO> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.UpdateEmployee(request.id, request.employee));
        }
    }
}
