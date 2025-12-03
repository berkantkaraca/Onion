using Microsoft.Extensions.DependencyInjection;
using Onion.Application.MappingProfiles;

namespace Onion.Application.DependencyResolvers
{
    public static class DtoMapperResolver
    {
        public static void AddDtoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoMappingProfile));
        }
    }
}
