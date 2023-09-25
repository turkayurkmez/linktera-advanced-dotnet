using eshop.DataTransferObjects.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eshop.MVC.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public MenuViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _mediator.Send(new GetCategoryMenuRequest());
            return View(categories);
        }
    }
}
