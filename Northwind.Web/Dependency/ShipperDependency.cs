using Microsoft.Extensions.DependencyInjection;
using Northwind.Web.IServices;


namespace Northwind.Web.DependencyInjection
{
    public static class ShipperDependency
    {
        public static void AddShippersDependency(this IServiceCollection service)
        {
            service.AddHttpClient<IShippersServices, ShipperServices>();
        }
    }
}
