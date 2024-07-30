
using Northwind.Web.IServices;

namespace Northwind.Web.Dependency
{
    public static class ShipperDependency
    {
        public static void AddShippersDependency(this IServiceCollection service)
        {
            service.AddHttpClient<IShippersServices, ShipperServices>();
        }
    }
}
