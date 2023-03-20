using DapperImplementation.DAL.Infrastructure;
using DapperImplementation.DAL.Repository;
using DapperImplementation.DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DapperImplementation.DAL
{
    public static class DALServiceConfiguration
    {
        public static void AddServicesFromDAL(this IServiceCollection services)
        {
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
