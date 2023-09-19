using AutoMapper;
using eshop.DataTransferObjects.Responses;
using eshop.Entities;

namespace eshop.Application.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductCardResponse>();
        }
    }
}
