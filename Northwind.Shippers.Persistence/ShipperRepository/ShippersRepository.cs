using Microsoft.EntityFrameworkCore;
using Northwind.Shippers.Domain.Entities;
using Northwind.Shippers.Domain.Interface;
using Northwind.Shippers.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using DomainEntities = Northwind.Shippers.Domain.Entities;

namespace Northwind.Shippers.Persistence.Repository
{
    public class ShippersRepository : IShippersRepository
    {
        private readonly NorthwindContext _context;

        public ShippersRepository(NorthwindContext context)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<DomainEntities.Shippers, bool>> filter)
        {
            return _context.Shippers.Any(filter);
        }

        public List<DomainEntities.Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }

        public DomainEntities.Shippers GetEntityBy(int ID)
        {
            return _context.Shippers.Find(ID);
        }

        public List<DomainEntities.Shippers> GetShippers()
        {
            return _context.Shippers.ToList();
        }

        public void Remove(DomainEntities.Shippers entity)
        {
            _context.Shippers.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(DomainEntities.Shippers entity)
        {
            _context.Shippers.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DomainEntities.Shippers entity)
        {
            _context.Shippers.Update(entity);
            _context.SaveChanges();
        }
    }
}
