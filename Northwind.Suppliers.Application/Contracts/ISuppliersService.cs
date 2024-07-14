using Northwind.Suppliers.Application.Base;
using Northwind.Suppliers.Application.Dtos;

public interface ISuppliersService
{
    ServiceResult GetAll();
    ServiceResult GetById(int id);
    ServiceResult Add(SuppliersDtoSave suppliersDtoSave);
    ServiceResult Update(SuppliersDtoUpdate suppliersDtoUpdate);
    ServiceResult Remove(SuppliersDtoRemove suppliersDtoRemove);
}
