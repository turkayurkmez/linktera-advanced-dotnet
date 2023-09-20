using eshop.DataTransferObjects.Requests;
using eshop.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly GetAllProductRequestHandler _productService;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetAllProductRequest());

            return View(products);
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var lastId = await _mediator.Send(request);
                _logger.LogInformation($"Kayıt gerceklesti.{lastId}");
                return Redirect("/");
            }

            return View();

        }
    }
}