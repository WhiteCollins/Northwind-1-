using Northwind.Common.Data.Repository;


namespace Northwind.Products.Domain.Interface
{
    public interface IProductRepository: IBaseRepository<Products.Domain.Entities.Product,int>
    {
        List<Products.Domain.Entities.Product> GetProducts();
    }
}
