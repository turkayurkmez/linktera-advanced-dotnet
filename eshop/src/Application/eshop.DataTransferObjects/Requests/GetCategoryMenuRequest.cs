using eshop.DataTransferObjects.Responses;
using MediatR;

namespace eshop.DataTransferObjects.Requests
{
    public class GetCategoryMenuRequest : IRequest<IEnumerable<CategoryMenuResponse>>
    {

    }
}
