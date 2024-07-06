using Microsoft.EntityFrameworkCore;
using Northwind.Suppliers.Domain.Interface;
using Northwind.Suppliers.Domain.Entities;
using Northwind.Suppliers.Persistence.Context;
using System.Linq.Expressions;
using Northwind.Common.Data.Repository;
using System.Linq;

namespace Northwind.Suppliers.Persistence.Repository
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly NorthwindContext _context;

        public SuppliersRepository(NorthwindContext context)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<Domain.Entities.Suppliers, bool>> filter)
        {
            return _context.Suppliers.Any(filter);
        }

        

        public List<Domain.Entities.Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public Domain.Entities.Suppliers GetEntityBy(int ID)
        {
            return _context.Suppliers.Find(ID);
        }

        public List<Domain.Entities.Suppliers> GetShippers()
        {
            return _context.Suppliers.ToList();
        }

        public List<Domain.Entities.Suppliers> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Suppliers entity)
        {
            _context.Suppliers.Remove(entity);
            _context.SaveChanges();
        }


        public void Save(Domain.Entities.Suppliers entity)
        {
            _context.Suppliers.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Domain.Entities.Suppliers entity)
        {
            _context.Suppliers.Update(entity);
            _context.SaveChanges();
        }

        List<Domain.Entities.Suppliers> IBaseRepository<Domain.Entities.Suppliers, int>.GetAll()
        {
            throw new NotImplementedException();
        }

        Domain.Entities.Suppliers IBaseRepository<Domain.Entities.Suppliers, int>.GetEntityBy(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
