using MediatR;
using Shared.Models;

namespace ServerApp.Commands
{
    public record AddEmployeeCommand(EmployeeDTO employee) : IRequest<EmployeeDTO>;
}
