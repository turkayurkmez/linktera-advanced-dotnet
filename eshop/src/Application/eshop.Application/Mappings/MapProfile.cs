using AutoMapper;
using eshop.DataTransferObjects.Requests;
using eshop.DataTransferObjects.Responses;
using eshop.Entities;

namespace eshop.Application.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductCardResponse>().ForMember(
                p => p.CategoryName,
                s => s.MapFrom(x => x.Category.Name)
                );
            CreateMap<CreateNewProductRequest, Product>();
            CreateMap<Category, CategoryMenuResponse>();
        }
    }
}
