using Northwind.Web.Models;
namespace Northwind.Web.Result.ShippersResult
{
    public class ShippersGetListResult: BaseResult
    {
        public List<ShippersBaseModel> result { get; set; }
    }
}
