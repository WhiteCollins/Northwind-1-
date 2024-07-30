
using Northwind.Web.IServices;


namespace Northwind.Web.DependencyInjection
{
    public static class ProductDependency
    {
        public static void AddProductsDependency(this IServiceCollection service)
        {
            service.AddHttpClient<IProductsServices, ProductServices>();
        }
    }
}
