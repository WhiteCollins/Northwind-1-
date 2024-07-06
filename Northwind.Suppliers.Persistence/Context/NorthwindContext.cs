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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierID);
                entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(40);
                entity.Property(e => e.ContactName).HasMaxLength(30);
                entity.Property(e => e.ContactTitle).HasMaxLength(30);
                entity.Property(e => e.Address).HasMaxLength(60);
                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.Region).HasMaxLength(15);
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.Country).HasMaxLength(15);
                entity.Property(e => e.Phone).HasMaxLength(24);
                entity.Property(e => e.Fax).HasMaxLength(24);
                entity.Property(e => e.HomePage).HasColumnType("ntext");
            });
        }

    }
}
