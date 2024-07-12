using Northwind.Common.Data.Repository;


namespace Northwind.Products.Domain.Interface
{
    public interface IProductRepository: IBaseRepository<Products.Domain.Entities.Products,int>
    {
        List<Products.Domain.Entities.Products> GetProducts();
    }
}
