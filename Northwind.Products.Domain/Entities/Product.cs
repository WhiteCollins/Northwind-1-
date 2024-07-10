using Northwind.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Northwind.Products.Domain.Entities
{
    public class Product : AuditEntity<int>
    {
        [Column("ProductID")]
        public override int Id { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(40)]
        public string? ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string? QuantityPerUnit { get; set; } 
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; } 
        public bool Discontinued { get; set; }
        public short? ReorderLevel { get; internal set; }
        public short? UnitsOnOrder { get; internal set; }
    }
}
