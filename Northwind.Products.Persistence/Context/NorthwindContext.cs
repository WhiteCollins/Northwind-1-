using Microsoft.EntityFrameworkCore;
using Northwind.Products.Domain.Entities;

namespace Northwind.Products.Persistence.Context
{
    public class NorthwindContext: DbContext
    {
        #region "Constructor"

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
            { 
 }
        #endregion

        #region "Db Sets"
        public DbSet<Product> Products { get; set; }   
        public DbSet<Domain.Entities.Product> Product { get; set; }
        #endregion

    }
}
