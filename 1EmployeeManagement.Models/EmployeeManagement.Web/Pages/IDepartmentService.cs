using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public interface IDepartmentService
    {
        Task GetDepartments();
    }
}