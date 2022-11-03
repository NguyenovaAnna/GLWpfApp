using DataAccess.Repository;
using MediatR;
using ServerApp.Commands;
using ServerApp.Queries;
using ServerApp.Services;
using Shared.Models;

namespace ServerApp.Handlers.EmployeeHandlers
{
    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeerepo;
        //private readonly IEmployeesData _data;

        public RemoveEmployeeCommandHandler(IEmployeeRepository employeerepo)
        {
            _employeerepo = employeerepo;
        }
        public async Task<Unit> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            _employeerepo.Delete(request.id);
            //_data.RemoveEmployee(request.id);
            return Unit.Value;
        }
    }
}
