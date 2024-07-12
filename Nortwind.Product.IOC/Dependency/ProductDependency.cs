using Microsoft.Extensions.DependencyInjection;
using Northwind.Products.Application.Contracts;
using Northwind.Products.Application.Services;
using Northwind.Products.Domain.Interface;
using Northwind.Products.Persistence.Repository;


namespace Nortwind.Product.IOC.Dependency
{
    public static class ProductDependency
    {
        public static void AddProductDependency(this IServiceCollection services)
        {
            #region"Repositorios"
            services.AddScoped<IProductRepository, ProductRepository>();
            #endregion

            #region"Services"
            services.AddTransient<IProductService, ProductService>();
            #endregion
        }
    }
}
