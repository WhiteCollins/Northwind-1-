

namespace Northwind.Products.Application.Dtos
{
    public class ProductDtoBase
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int? SupplierID { get; internal set; }
        public int? CategoryID { get; internal set; }
        public short? UnitsOnOrder { get; internal set; }
        public short? ReorderLevel { get; internal set; }
        public bool Discontinued { get; internal set; }
    }
}
