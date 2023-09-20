using AutoMapper;
using eshop.Data.Repositories;
using eshop.DataTransferObjects.Requests;
using eshop.Entities;
using MediatR;

namespace eshop.Application.Handlers
{
    public class CreateNewProductRequestHandler : IRequestHandler<CreateNewProductRequest, int>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;

        public CreateNewProductRequestHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateNewProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.CreateAsync(product);
            return product.Id;
        }
    }
}
