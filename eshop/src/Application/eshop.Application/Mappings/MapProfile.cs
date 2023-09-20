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
            CreateMap<Product, ProductCardResponse>();
            CreateMap<CreateNewProductRequest, Product>();
            CreateMap<Category, CategoryMenuResponse>();
        }
    }
}
