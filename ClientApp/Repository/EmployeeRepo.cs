using ClientApp.Models;
using ClientApp.ViewModels;
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
using System.Configuration;
using AutoMapper;

namespace ClientApp.Repository
{
    public class EmployeeRepo
    {
        
        static readonly HttpClient httpClient = new HttpClient();
        string url = ConfigurationManager.AppSettings["url"];

        public EmployeeRepo()
        {
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> GetCallAsync(string path)
        {
            HttpResponseMessage response = await httpClient.GetAsync(path);
            return response;
        }

        public async Task<HttpResponseMessage> PostCallAsync(string path, EmployeeDisplayModel newEmployee)
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

        public async Task<HttpResponseMessage> PutCallAsync(string path, EmployeeDisplayModel employee)
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
    }
}
