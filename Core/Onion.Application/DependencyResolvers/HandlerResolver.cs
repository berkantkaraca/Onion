using Microsoft.Extensions.DependencyInjection;
using Onion.Application.CqrsAndMediatr.CQRS.Handlers.Modify;
using Onion.Application.CqrsAndMediatr.CQRS.Handlers.Read;

namespace Onion.Application.DependencyResolvers
{
    public static class HandlerResolver
    {
        public static void AddHandlerService(this IServiceCollection services)
        {
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(GetCategoryByIdQueryHandler).Assembly));
        }
    }
}
