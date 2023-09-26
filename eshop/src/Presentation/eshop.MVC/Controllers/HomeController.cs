using eshop.DataTransferObjects.Requests;
using eshop.DataTransferObjects.Responses;
using eshop.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Index(int page = 1, string order = "Id")
        {

            var products = await _mediator.Send(new GetAllProductRequest());
            PageModel pageModel = new PageModel
            {
                PageSize = 2,
                TotalItems = products.Count(),
                CurrentPage = page
            };


            IOrderedEnumerable<ProductCardResponse> orderedProducts = null;
            switch (order)
            {
                case "Id":
                    orderedProducts = products.OrderBy(p => p.Id);
                    break;
                case "Price":
                    orderedProducts = products.OrderBy(p => p.Price);

                    break;
                default:
                    orderedProducts = products.OrderBy(p => p.CategoryName);
                    break;
            }

            var paginated = orderedProducts
                                    .Skip(pageModel.PageSize * (page - 1))
                                    .Take(pageModel.PageSize)
                                    .ToList();

            var model = new ProductsViewModel
            {
                Products = paginated,
                PageModel = pageModel
            };
            return View(model);
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

        [Authorize(Roles = "Admin")]
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