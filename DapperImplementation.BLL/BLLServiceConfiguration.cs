using DapperImplementation.BLL.Services;
using DapperImplementation.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DapperImplementation.DAL
{
    public static class BLLServiceConfiguration
    {
        public static void AddServicesFromBLL(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
