using MediatR;
using ServerApp.Commands;
using ServerApp.Queries;
using ServerApp.Services;
using Shared.Models;

namespace ServerApp.Handlers
{
    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
    {
        private readonly IEmployeesData _data;

        public RemoveEmployeeCommandHandler(IEmployeesData data)
        {
            _data = data;
        }
        public async Task<Unit> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            _data.RemoveEmployee(request.id);
            return Unit.Value;
        }
    }
}
