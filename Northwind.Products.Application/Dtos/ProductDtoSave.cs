using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Products.Application.Dtos
{
    public class ProductDtoSave: ProductDtoBase
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; } // Debe ser int
        public int CategoryID { get; set; } // Debe ser int
        public string QuantityPerUnit { get; set; } // Debe ser string
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; } // Debe ser short
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
