using _1EmployeeManagement.Models;
using EmployeeManagement.Web.Pages;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepatmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepatmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<Department> GetDepartment(int id)
        {
            return await httpClient.GetJsonAsync<Department>($"api/departments/{id}");
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await httpClient.GetJsonAsync<Department[]>("api/departments");
        }

    }
}
