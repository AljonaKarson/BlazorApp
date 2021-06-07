using _1EmployeeManagement.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee updateEmployee);
        Task<Employee> CreateEmployee(Employee newEmployee);
        Task DeleteEmployee(int id);
        Task GetEmployee();
    }
}