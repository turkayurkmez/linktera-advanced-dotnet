using AutoMapper;
using eshop.Data.Repositories;
using eshop.DataTransferObjects.Requests;
using eshop.DataTransferObjects.Responses;
using MediatR;

namespace eshop.Application.Handlers
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, ProductCardResponse>
    {

        private readonly IMapper _mapper;
        private readonly IProductRepositoryAsync _productRepositoryAsync;

        public GetProductByIdRequestHandler(IMapper mapper, IProductRepositoryAsync productRepositoryAsync)
        {
            _mapper = mapper;
            _productRepositoryAsync = productRepositoryAsync;
        }

        public async Task<ProductCardResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepositoryAsync.GetByIdAsync(request.Id);
            return _mapper.Map<ProductCardResponse>(product);
        }
    }
}
