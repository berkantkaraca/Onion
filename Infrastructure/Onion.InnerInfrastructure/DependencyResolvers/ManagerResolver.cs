using Microsoft.Extensions.DependencyInjection;
using Onion.Application.ManagerInterfaces;
using Onion.InnerInfrastructure.ManagerConcretes;

namespace Onion.InnerInfrastructure.DependencyResolvers
{
    public static class ManagerResolver
    {
        public static void AddManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IProductManager, ProductManager>();
        }
    }
}
