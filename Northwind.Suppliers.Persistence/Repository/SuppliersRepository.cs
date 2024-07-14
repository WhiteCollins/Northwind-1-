using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Northwind.Suppliers.Domain.Interface;
using Northwind.Suppliers.Domain.Entities;
using Northwind.Suppliers.Persistence.Context;

namespace Northwind.Suppliers.Persistence.Repository
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly NorthwindContext _context;
        private readonly ILogger<SuppliersRepository> _logger;

        public SuppliersRepository(NorthwindContext context, ILogger<SuppliersRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Exists(Expression<Func<Domain.Entities.Suppliers, bool>> filter)
        {
            return _context.Suppliers.Any(filter);
        }

        public List<Domain.Entities.Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public Domain.Entities.Suppliers GetEntityBy(int id)
        {
            try
            {
                var supplier = _context.Suppliers.Find(id);

                if (supplier is null)
                    throw new Exception("Supplier not found.");

                return supplier;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obtaining the supplier.");
                throw;
            }
        }

        public List<Domain.Entities.Suppliers> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("The supplier entity cannot be null.");

                var supplierToRemove = _context.Suppliers.Find(entity.Id);

                if (supplierToRemove is null)
                    throw new Exception("The supplier you want to delete is not found.");

                _context.Suppliers.Remove(supplierToRemove);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing the supplier.");
                throw;
            }
        }

        public void Save(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("The supplier entity cannot be null.");

                if (Exists(s => s.Id == entity.Id))
                    throw new Exception("The supplier is already registered.");

                _context.Suppliers.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding the supplier.");
                throw;
            }
        }

        public void Update(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("The supplier entity cannot be null.");

                var supplierToUpdate = _context.Suppliers.Find(entity.Id);

                if (supplierToUpdate is null)
                    throw new Exception("The supplier you want to update is not found.");

                supplierToUpdate.CompanyName = entity.CompanyName;
                supplierToUpdate.ContactName = entity.ContactName;
                supplierToUpdate.ContactTitle = entity.ContactTitle;
                supplierToUpdate.Address = entity.Address;
                supplierToUpdate.City = entity.City;
                supplierToUpdate.Region = entity.Region;
                supplierToUpdate.PostalCode = entity.PostalCode;
                supplierToUpdate.Country = entity.Country;
                supplierToUpdate.Phone = entity.Phone;
                supplierToUpdate.Fax = entity.Fax;
                supplierToUpdate.HomePage = entity.HomePage;

                _context.Entry(supplierToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating the supplier.");
                throw;
            }
        }
    }
}
