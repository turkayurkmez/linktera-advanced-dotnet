using AutoMapper;
using eshop.Data.Repositories;
using eshop.DataTransferObjects.Requests;
using eshop.DataTransferObjects.Responses;
using MediatR;

namespace eshop.Application.Handlers
{
    public class GetCategoryMenuRequestHandler : IRequestHandler<GetCategoryMenuRequest, IEnumerable<CategoryMenuResponse>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryMenuRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryMenuResponse>> Handle(GetCategoryMenuRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryMenuResponse>>(categories);
        }
    }
}
