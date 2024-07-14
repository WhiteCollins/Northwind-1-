using Northwind.Products.Domain.Entities;
using System.Linq.Expressions;


namespace Northwind.Products.Domain.Interface
{
    public interface IProductRepository
    {
        List<Products.Domain.Entities.Product> GetProducts();
        bool Exists(Expression<Func<Product, bool>> filter);
        List<Product> GetAll();
        Product GetEntityBy(int id);
        void Remove(Product entity);
        void Save(Product entity);
        void Update(Product entity);
    }
}
