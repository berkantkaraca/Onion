using AutoMapper;
using Onion.Application.DtoClasses;
using Onion.WebApi.Models.RequestModels.Categories;
using Onion.WebApi.Models.ResponseModels.Categories;

namespace Onion.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();
        }
    }
}
