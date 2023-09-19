using AutoMapper;
using eshop.Data.Repositories;
using eshop.DataTransferObjects.Requests;
using eshop.DataTransferObjects.Responses;

namespace eshop.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositoryAsync _productRepositoryAsync;
        private readonly IMapper _mapper;

        public ProductService(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
        {
            _productRepositoryAsync = productRepositoryAsync;
            _mapper = mapper;
        }

        public Task CreateNewAsync(CreateNewProductRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductCardResponse>> GetAllAsync()
        {
            var products = await _productRepositoryAsync.GetAllAsync();
            var response = _mapper.Map<IEnumerable<ProductCardResponse>>(products);

            return response;

        }
    }
}
