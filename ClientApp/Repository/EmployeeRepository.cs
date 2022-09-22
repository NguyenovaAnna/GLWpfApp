using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Repository
{
    public class EmployeeRepository
    {
        
        static readonly HttpClient httpClient = new HttpClient();
        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeRepository()
        {
            Employees = new ObservableCollection<Employee>();
            var task = GetEmployees();
        }

        public async Task GetEmployees()
        {
            var response = await GetCallAsync("api/employees");

            if (response.IsSuccessStatusCode)
            {
                var emps = await response.Content.ReadAsAsync<ObservableCollection<Employee>>();

                foreach (var emp in emps)
                {
                    var newEmployee = new Employee(emp.FirstName, emp.LastName, emp.EmployeeNumber, emp.MiddleName, emp.NationalIdNumber,
                                                    emp.PreviousIdNumber, emp.PersonellNumber, emp.ActivationTime, emp.ExpirationTime, emp.ContactMethods);

                    Employees.Add(newEmployee);
                }
            }
        }

        public async Task<HttpResponseMessage> GetCallAsync(string path)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7168/");
            HttpResponseMessage response = await httpClient.GetAsync(path);
            return response;
        }

        public async Task<HttpResponseMessage> PostCallAsync(string path, Employee newEmployee)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(path, newEmployee);
            return response;
        }

        public async Task<HttpResponseMessage> PutCallAsync(string path, Employee employee)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(path, employee);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteCallAsync(string path)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(path);
            return response;
        }
    }
}
