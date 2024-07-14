using Northwind.Common.Data.Repository;


namespace Northwind.Suppliers.Domain.Interface
{
    public interface ISuppliersRepository: IBaseRepository<Suppliers.Domain.Entities.Suppliers,int>
    {
        List<Suppliers.Domain.Entities.Suppliers> GetSuppliers();
    }
}
