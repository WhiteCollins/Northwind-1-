using Northwind.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Suppliers.Domain.Interface
{
    public interface ISuppliersRepository: IBaseRepository<Suppliers.Domain.Entities.Suppliers,int>
    {
        List<Suppliers.Domain.Entities.Suppliers> GetSuppliers();
    }
}
