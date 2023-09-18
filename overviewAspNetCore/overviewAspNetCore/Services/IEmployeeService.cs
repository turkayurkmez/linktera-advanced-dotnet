using overviewAspNetCore.Models;

namespace overviewAspNetCore.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }
}