using Microsoft.EntityFrameworkCore;
using Northwind.Suppliers.Domain.Entities;

namespace Northwind.Suppliers.Persistence.Context
{
    public class NorthwindContext: DbContext
    {
        #region "Constructor"

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {
        }
        #endregion

        #region "Db Sets"
        public DbSet<Domain.Entities.Suppliers> Suppliers { get; set; }
        #endregion

    }
}
