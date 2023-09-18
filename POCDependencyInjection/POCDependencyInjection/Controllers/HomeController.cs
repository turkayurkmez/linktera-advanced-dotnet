using Microsoft.AspNetCore.Mvc;
using POCDependencyInjection.Models;
using System.Diagnostics;

namespace POCDependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingleton _singleton;
        private readonly ITransient _transient;
        private readonly IScoped _scoped;
        private readonly ServiceHelper serviceHelper;
        public HomeController(ILogger<HomeController> logger, ISingleton singleton, ITransient transient, IScoped scoped, ServiceHelper serviceHelper)
        {
            _logger = logger;
            _singleton = singleton;
            _transient = transient;
            _scoped = scoped;
            this.serviceHelper = serviceHelper;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = _singleton.Guid.ToString();
            ViewBag.Transient = _transient.Guid.ToString();
            ViewBag.Scoped = _scoped.Guid.ToString();

            ViewBag.ServiceSingleton = serviceHelper.Singleton.Guid.ToString();
            ViewBag.ServiceTransient = serviceHelper.Transient.Guid.ToString();
            ViewBag.ServiceScoped = serviceHelper.Scoped.Guid.ToString();

            return View();
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