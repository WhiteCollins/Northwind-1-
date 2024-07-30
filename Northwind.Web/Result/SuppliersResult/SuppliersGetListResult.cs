using Northwind.Web.Models;
namespace Northwind.Web.Result.SuppliersResult
{
    public class SuppliersGetListResult : BaseResult
    {
        public List<SuppliersBaseModel> result { get; set; }
    }
}
