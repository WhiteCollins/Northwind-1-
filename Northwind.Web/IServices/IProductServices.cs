using Northwind.Web.Models;
using Northwind.Web.Result.ProductResult;
using Northwind.Web.Result;

namespace Northwind.Web.IServices
{
    public interface IProductsServices
    {
        Task<ProductGetListResult> GetProductsAsync();
        Task<ProductGetResult> GetProductByIdAsync(int id);
        Task<BaseResult> CreateProductAsync(ProductBaseModel product);
        Task<BaseResult> UpdateProductAsync(int id, ProductBaseModel product);
        Task<BaseResult> DeleteProductAsync(int id);
    }
}
