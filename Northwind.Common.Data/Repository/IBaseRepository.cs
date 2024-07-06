using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Northwind.Common.Data.Base;

namespace Northwind.Common.Data.Repository
{
    public interface IBaseRepository<TEntity, TType> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetEntityBy(TType ID);
        bool Exists(Expression<Func<TEntity, bool>> filter);
    }
}
