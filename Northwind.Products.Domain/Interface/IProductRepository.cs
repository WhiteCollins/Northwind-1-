using Northwind.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Products.Domain.Interface
{
    public interface IProductRepository: IBaseRepository<Products.Domain.Entities.Product,int>
    {
        List<Products.Domain.Entities.Product> GetProducts();
    }
}
