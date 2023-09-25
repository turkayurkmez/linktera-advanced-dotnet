using eshop.DataTransferObjects.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllProductRequest());
            return Ok(products);

        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetProductByIdRequest { Id = id };
            var response = await _mediator.Send(request);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound(new { message = $"{id} id'li ürün bulunamadı." });

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProduct(CreateNewProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var lastId = await _mediator.Send(request);
                return CreatedAtAction(nameof(Get), routeValues: new { id = lastId }, null);

            }
            return BadRequest(ModelState);
        }
    }
}
