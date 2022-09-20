using GLWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GLWpfApp.Repository
{
    public class EmployeeRepository
    {
               
        static readonly HttpClient httpClient = new HttpClient();
     
        public async Task<ObservableCollection<Employee>> GetEmployeesAsync(string path)
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            var response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadAsAsync<ObservableCollection<Employee>>();
            }
            return employees;    
        }
    }
}
