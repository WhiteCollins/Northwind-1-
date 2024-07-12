using Microsoft.Extensions.DependencyInjection;
using Northwind.Shippers.Domain.Interface;
using Northwind.Shippers.Persistence.Repository;
using Northwind.Shippers.Application.Services;
using Northwind.Shippers.Application.Contracts;

namespace Northwind.Shippers.IOC.Dependency
{
    public static class ShippersDependency
    {
        public static void AddShippersDependency(this IServiceCollection services)
        {
            #region "Repositorios"
            services.AddScoped<IShippersRepository, ShippersRepository>();
            #endregion

            #region "Services"
            services.AddTransient<IShippersService, ShipperService>();
            #endregion
        }
    }
}
