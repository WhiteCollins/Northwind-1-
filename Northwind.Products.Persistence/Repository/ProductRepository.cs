using Microsoft.EntityFrameworkCore;
using Northwind.Products.Domain.Interface;
using Northwind.Products.Domain.Entities;
using Northwind.Products.Persistence.Context;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace Northwind.Products.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(NorthwindContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Exists(Expression<Func<Product, bool>> filter)
        {
            return _context.Products.Any(filter);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetEntityBy(int id)
        {
            try
            {
                var product = _context.Products.Find(id);

                if (product == null)
                    throw new InvalidOperationException("Product not found.");

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error obtaining the product.", ex);
                throw;
            }
        }

        public void Remove(Product entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("The entity product cannot be null.");

                var productToRemove = _context.Products.Find(entity.ProductID);

                if (productToRemove == null)
                    throw new InvalidOperationException("The product you want to delete is not found.");

                _context.Products.Remove(productToRemove);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Concurrency conflict: The entity was modified or deleted by another process.", ex);
                throw new InvalidOperationException("Concurrency conflict: The entity was modified or deleted by another process.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error removing the product.", ex);
                throw;
            }
        }

        public void Save(Product entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("The entity product cannot be null.");

                if (Exists(p => p.ProductID == entity.ProductID))
                    throw new InvalidOperationException("The product is already registered.");

                _context.Products.Add(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError("Error adding the product: {0}", dbEx.InnerException?.Message ?? dbEx.Message);
                if (dbEx.InnerException != null)
                {
                    _logger.LogError("Inner exception: {0}", dbEx.InnerException.ToString());
                }
                throw new InvalidOperationException("An error occurred while saving the product. See the inner exception for details.", dbEx);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error adding the product.", ex);
                throw;
            }
        }



        public void Update(Product entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("The entity product cannot be null.");

                var productToUpdate = _context.Products.Find(entity.ProductID);

                if (productToUpdate == null)
                    throw new InvalidOperationException("The product you want to update is not found.");

                productToUpdate.CategoryID = entity.CategoryID;
                productToUpdate.SupplierID = entity.SupplierID;
                productToUpdate.ProductName = entity.ProductName;
                productToUpdate.UnitPrice = entity.UnitPrice;
                productToUpdate.UnitsInStock = entity.UnitsInStock;
                productToUpdate.UnitsOnOrder = entity.UnitsOnOrder;
                productToUpdate.ReorderLevel = entity.ReorderLevel;
                productToUpdate.Discontinued = entity.Discontinued;


                _context.Entry(productToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating the product.", ex);
                throw;
            }
        }
    }
}
