using MediatR;
using Shared.Models;

namespace ServerApp.Commands
{
    public record RemoveEmployeeCommand(int id) : IRequest;

}
