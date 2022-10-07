using DataAccess.Entities;
using MediatR;
using Shared.Models;

namespace ServerApp.Queries
{
    public record GetAllEmployeesQuery() : IRequest<List<EmployeeDTO>>;
    
}
