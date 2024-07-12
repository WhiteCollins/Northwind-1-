

using Northwind.Suppliers.Application.Base;
using Northwind.Suppliers.Application.Dtos;

namespace Northwind.Suppliers.Application.Contracts
{
    public interface ISuppliersService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
        ServiceResult Add(SuppliersDtoBase suppliers);
        ServiceResult Update(SuppliersDtoBase suppliers);
        ServiceResult Remove(SuppliersDtoRemove suppliers);
    }
}
