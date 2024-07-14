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
            // Verificar si la entidad existe en la base de datos
            var existingEntity = _context.Products.Find(entity.ProductID);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("The entity does not exist in the database.");
            }

            try
            {
                _context.Products.Remove(existingEntity);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Manejar la excepción de concurrencia
                throw new InvalidOperationException("Concurrency conflict: The entity was modified or deleted by another process.", ex);
            }
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
