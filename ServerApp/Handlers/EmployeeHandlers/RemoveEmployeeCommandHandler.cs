using DataAccess.Repository;
using MediatR;
using ServerApp.Commands;
using ServerApp.Queries;
using Shared.Models;

namespace ServerApp.Handlers.EmployeeHandlers
{
    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeerepo;

        public RemoveEmployeeCommandHandler(IEmployeeRepository employeerepo)
        {
            _employeerepo = employeerepo;
        }
        public Task<Unit> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
           _employeerepo.Delete(request.id);
           return Task.FromResult(Unit.Value);
        }
    }
}
