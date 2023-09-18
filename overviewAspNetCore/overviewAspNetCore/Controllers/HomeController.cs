using Microsoft.AspNetCore.Mvc;
using overviewAspNetCore.Models;
using overviewAspNetCore.Services;
using System.Diagnostics;

namespace overviewAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService service;

        public HomeController(ILogger<HomeController> logger, IEmployeeService service)
        {
            _logger = logger;
            this.service = service;
        }

        public IActionResult Index()
        {

            //  EmployeeService employeeService = new EmployeeService();
            var employees = service.GetEmployees();
            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}