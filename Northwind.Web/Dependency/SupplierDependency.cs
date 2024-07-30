
using Northwind.Web.IServices;

namespace Northwind.Web.DependencyInjection
{
    public static class SupplierDependency
    {
        public static void AddSuppliersDependency(this IServiceCollection service)
        {
            service.AddHttpClient<ISuppliersServices, SupplierServices>();
        }
    }
}
