using _1EmployeeManagement.Models;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public interface IEmployeeService
    {
        Task GetEmployees();
        Task<Employee> GetEmployee(int v);
    }
}