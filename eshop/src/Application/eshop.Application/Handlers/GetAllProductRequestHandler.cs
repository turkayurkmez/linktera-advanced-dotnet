using AutoMapper;
using eshop.Data.Repositories;
using eshop.DataTransferObjects.Requests;
using eshop.DataTransferObjects.Responses;
using MediatR;

namespace eshop.Application.Handlers
{
    public class GetAllProductRequestHandler : IRequestHandler<GetAllProductRequest, IEnumerable<ProductCardResponse>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductRequestHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<ProductCardResponse>> Execute()
        //{
        //    var products = await _productRepository.GetAllAsync();
        //    var response = _mapper.Map<IEnumerable<ProductCardResponse>>(products);
        //    return response;

        //}

        public async Task<IEnumerable<ProductCardResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<ProductCardResponse>>(products);
            return response;
        }
    }
}
