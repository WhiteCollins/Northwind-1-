using Microsoft.EntityFrameworkCore;
using Northwind.Shippers.Domain.Entities;
using Northwind.Common.Data.Base;

namespace Northwind.Shippers.Persistence.Context
{
    public class NorthwindContext : DbContext
    {
        #region "Constructor"

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {
        }
        #endregion

        #region "Db Sets"
        public DbSet<Domain.Entities.Shippers> Shippers { get; set; }
        #endregion

    }
}