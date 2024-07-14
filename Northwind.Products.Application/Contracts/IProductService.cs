using Northwind.Products.Application.Core;
using Northwind.Products.Application.Dtos;

namespace Northwind.Products.Application.Contracts
{
    public interface IProductService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
        ServiceResult Add(ProductDtoBase product);
        ServiceResult Update(ProductDtoUpdate product);
        ServiceResult Remove(ProductDtoRemove product);
    }
}
