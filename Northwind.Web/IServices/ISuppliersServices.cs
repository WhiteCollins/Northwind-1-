using Northwind.Web.Models;
using Northwind.Web.Result.SuppliersResult;
using Northwind.Web.Result;

namespace Northwind.Web.IServices
{
    public interface ISuppliersServices
    {
        Task<SuppliersGetListResult> GetSuppliersAsync();
        Task<SupplierGetResult> GetSupplierByIdAsync(int id);
        Task<BaseResult> CreateSupplierAsync(SuppliersBaseModel supplier);
        Task<BaseResult> UpdateSupplierAsync(int id, SuppliersBaseModel supplier);
        Task<BaseResult> DeleteSupplierAsync(int id);
    }
}
