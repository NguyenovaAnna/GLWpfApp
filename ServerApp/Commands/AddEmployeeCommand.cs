using MediatR;
using Shared.Models;

namespace ServerApp.Commands
{
    public record AddEmployeeCommand(EmployeeDTO employee) : IRequest<EmployeeDTO>;

    //public record AddEmployeeCommand(string firstName, string lastName, int employeeNumber, string middleName, int nationalIdNumber, int previousIdNumber, int personellNumber, DateTime activationTime, DateTime expirationTime, List<ContactMethodDTO> contactMethods) : IRequest<EmployeeDTO>;


}
