using eshop.DataTransferObjects.Responses;
using MediatR;

namespace eshop.DataTransferObjects.Requests
{
    public class GetProductByIdRequest : IRequest<ProductCardResponse>
    {
        public int Id { get; set; }

    }
}
