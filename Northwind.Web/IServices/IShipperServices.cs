using Northwind.Web.Models;
using Northwind.Web.Result.ShippersResult;
using Northwind.Web.Result;

namespace Northwind.Web.IServices
{
    public interface IShippersServices
    {
        Task<ShippersGetListResult> GetShippersAsync();
        Task<ShipperGetResult> GetShipperByIdAsync(int id);
        Task<BaseResult> CreateShipperAsync(ShippersBaseModel shipper);
        Task<BaseResult> UpdateShipperAsync(int id, ShippersBaseModel shipper);
        Task<BaseResult> DeleteShipperAsync(int id);
    }
}
