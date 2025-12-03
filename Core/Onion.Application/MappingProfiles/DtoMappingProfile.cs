using AutoMapper;
using Onion.Application.DtoClasses;
using Onion.Domain.Entities;

namespace Onion.Application.MappingProfiles
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUserProfile, AppUserProfileDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
