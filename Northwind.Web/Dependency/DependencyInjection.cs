using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Web.IServices;
using Northwind.Web.Services;
using System;

namespace Northwind.Web.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddNorthwindDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var apiBaseAddresses = configuration.GetSection("ApiBaseAddresses");

            services.AddHttpClient<IProductsServices, ProductServices>(client =>
            {
                client.BaseAddress = new Uri(apiBaseAddresses["Products"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<IShippersServices, ShipperServices>(client =>
            {
                client.BaseAddress = new Uri(apiBaseAddresses["Shippers"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<ISuppliersServices, SupplierServices>(client =>
            {
                client.BaseAddress = new Uri(apiBaseAddresses["Suppliers"]);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            });
        }
    }
}
