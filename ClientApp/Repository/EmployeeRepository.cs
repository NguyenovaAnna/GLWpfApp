using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Repository
{
    public class EmployeeRepository : INotifyPropertyChanged
    {
        
        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get 
            { 
                return _employees; 
            }
            set 
            { 
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        static readonly HttpClient httpClient = new HttpClient();

        public EmployeeRepository()
        {
            Employees = new ObservableCollection<Employee>();
            Task task = GetEmployees();
        }

        public async Task GetEmployees()
        {
            var response = await GetCallAsync("https://localhost:7168/api/employees");

            if (response.IsSuccessStatusCode)
            {
                var emps = await response.Content.ReadAsAsync<ObservableCollection<Employee>>();

                Employees.Clear();

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
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(path);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> PostCallAsync(string path, Employee newEmployee)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(path, newEmployee);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> PutCallAsync(string path, Employee employee)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(path, employee);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> DeleteCallAsync(string path)
        {
            try
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(path);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
