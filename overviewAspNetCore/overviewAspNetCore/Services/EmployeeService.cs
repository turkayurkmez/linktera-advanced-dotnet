using overviewAspNetCore.Models;

namespace overviewAspNetCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> employees = new()
        {
            new(){ Id = 1, LastName="Ürkmez", Name="Türkay" },
            new(){ Id = 2, LastName="Çakıcı", Name="Bahar" },
            new(){ Id = 3, LastName="Aykan", Name="Enes" }

        };

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
