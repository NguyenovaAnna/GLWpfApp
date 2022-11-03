using DataAccess.Entities;
using MediatR;
using Shared.Models;

namespace ServerApp.Queries.EmployeeQueries
{
    public record GetAllEmployeesQuery() : IRequest<List<EmployeeDTO>>;
}
