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
        public DbSet<Domain.Entities.Product> Products { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductID);
                entity.Property(e => e.ProductID).HasColumnName("ProductID");
                entity.Property(e => e.ProductName).HasColumnName("ProductName").HasMaxLength(40).IsRequired();
                entity.Property(e => e.SupplierID).HasColumnName("SupplierID");
                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");
                entity.Property(e => e.QuantityPerUnit).HasColumnName("QuantityPerUnit").HasMaxLength(20);
                entity.Property(e => e.UnitPrice).HasColumnName("UnitPrice");
                entity.Property(e => e.UnitsInStock).HasColumnName("UnitsInStock");
                entity.Property(e => e.UnitsOnOrder).HasColumnName("UnitsOnOrder");
                entity.Property(e => e.ReorderLevel).HasColumnName("ReorderLevel");
                entity.Property(e => e.Discontinued).HasColumnName("Discontinued").IsRequired();
            });
        }
    }
}
