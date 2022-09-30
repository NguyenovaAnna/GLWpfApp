using MediatR;
using ServerApp.Queries;
using ServerApp.Services;
using Shared.Models;

namespace ServerApp.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeesData _data;
        public GetAllEmployeesQueryHandler(IEmployeesData data)
        {
            _data = data;
        }
        public Task<List<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetAllEmployees());
        }
    }
}
