using overviewAspNetCore.Models;

namespace overviewAspNetCore.Services
{
    public class SmurfEmployeeService : IEmployeeService
    {
        private List<Employee> employees = new()
        {
            new(){ Id = 1, LastName="Şirin", Name="Uykucu" },
            new(){ Id = 2, LastName="Şirin", Name="Gözlüklü" },
            new(){ Id = 3, LastName="Şirin", Name="Şakacı" }

        };

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
