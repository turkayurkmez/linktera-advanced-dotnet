using eshop.DataTransferObjects.Responses;
using MediatR;

namespace eshop.DataTransferObjects.Requests
{
    public class GetAllProductRequest : IRequest<IEnumerable<ProductCardResponse>>
    {
    }
}
