using Microsoft.Extensions.DependencyInjection;
using Northwind.Suppliers.Application.Services;
using Northwind.Suppliers.Domain.Interface;
using Northwind.Suppliers.Persistence.Repository;

namespace Northwind.Suppliers.IOC.Dependency
{
    public static class SuppliersDependency
    {
        public static void AddSuppliersDependency(this IServiceCollection services)
        {
            #region "Repositorios"
            services.AddScoped<ISuppliersService, SuppliersService>();
            #endregion

            #region "Services"
            services.AddTransient<ISuppliersRepository, SuppliersRepository>();
            #endregion
        }
    }
}
