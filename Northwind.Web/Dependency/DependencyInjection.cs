using Microsoft.Extensions.DependencyInjection;
using Northwind.Web.IServices;


namespace Northwind.Web.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddNorthwindDependencies(this IServiceCollection services)
        {
            services.AddHttpClient<IProductsServices, ProductServices>();
            services.AddHttpClient<IShippersServices, ShipperServices>();
            services.AddHttpClient<ISuppliersServices, SupplierServices>();
        }
    }
}

