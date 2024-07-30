using Northwind.Web.Models;

namespace Northwind.Web.Result.ProductResult
{
    public class ProductGetListResult: BaseResult
    {
        public List<ProductBaseModel> result { get; set; }
    }
}
