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
