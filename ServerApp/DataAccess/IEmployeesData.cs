using Shared.Models;

namespace ServerApp.Services
{
    public interface IEmployeesData
    {
        EmployeeDTO AddEmployee(EmployeeDTO employee);
        List<EmployeeDTO> GetAllEmployees();
        EmployeeDTO InsertEmployee(string firstName, string lastName, int employeeNumber, string middleName, int nationalIdNumber, int previousIdNumber, int personellNumber, DateTime activationTime, DateTime expirationTime, List<ContactMethodDTO> contactMethods);
        void RemoveEmployee(int id);
        EmployeeDTO UpdateEmployee(int id, EmployeeDTO employee);
    }
}