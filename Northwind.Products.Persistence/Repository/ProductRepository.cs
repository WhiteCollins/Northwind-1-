using Microsoft.EntityFrameworkCore;
using Northwind.Products.Domain.Interface;
using Northwind.Products.Domain.Entities;
using Northwind.Products.Persistence.Context;
using System.Linq.Expressions;

namespace Northwind.Products.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext _context;

        public ProductRepository(NorthwindContext context)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<Product, bool>> filter)
        {
            return _context.Products.Any(filter);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetEntityBy(int id)
        {
            return _context.Products.Find(id);
        }

        public void Remove(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }

        // Implementación del método GetProducts
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
