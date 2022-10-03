using MediatR;
using Shared.Models;

namespace ServerApp.Commands
{
    public record UpdateEmployeeCommand(int id, EmployeeDTO employee) : IRequest<EmployeeDTO>;

}
