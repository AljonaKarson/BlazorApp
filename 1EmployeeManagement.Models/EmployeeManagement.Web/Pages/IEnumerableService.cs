using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public interface IEnumerableService
    {
        Task GetEmployees();
    }
}