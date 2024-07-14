using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Products.Domain.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int ProductID { get; set; }

        [Required]
        [Column("ProductName")]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Column("SupplierID")]
        public int? SupplierID { get; set; }

        [Column("CategoryID")]
        public int? CategoryID { get; set; }

        [Column("QuantityPerUnit")]
        [StringLength(20)]
        public string? QuantityPerUnit { get; set; }

        [Column("UnitPrice")]
        public decimal? UnitPrice { get; set; }

        [Column("UnitsInStock")]
        public short? UnitsInStock { get; set; }

        [Column("UnitsOnOrder")]
        public short? UnitsOnOrder { get; set; }

        [Column("ReorderLevel")]
        public short? ReorderLevel { get; set; }

        [Required]
        [Column("Discontinued")]
        public bool Discontinued { get; set; }
    }
}
