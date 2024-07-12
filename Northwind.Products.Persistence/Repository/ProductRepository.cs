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

        public bool Exists(Expression<Func<Domain.Entities.Products, bool>> filter)
        {
            return _context.Products.Any(filter);
        }

        public List<Domain.Entities.Products> GetAll()
        {
            return _context.Products.ToList();
        }

        public Domain.Entities.Products GetEntityBy(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Domain.Entities.Products> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void Remove(Domain.Entities.Products entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(Domain.Entities.Products entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Domain.Entities.Products entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }
    }
}
