using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionPattern.Models;
using OptionPattern.Settings;
using System.Diagnostics;

namespace OptionPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptionsMonitor<SmtpSettings> _smtpOption;


        public HomeController(ILogger<HomeController> logger, IOptionsMonitor<SmtpSettings> smtpOption)
        {
            _logger = logger;
            _smtpOption = smtpOption;
        }

        public IActionResult Index()
        {
            var setting = _smtpOption.CurrentValue;
            return View(setting);
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