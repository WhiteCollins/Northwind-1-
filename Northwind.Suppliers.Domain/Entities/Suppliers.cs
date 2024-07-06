using Northwind.Common.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Suppliers.Domain.Entities
{
    public abstract class Suppliers: AuditEntity<int>
    {
        [Column("SuppliersID")]
        public override int Id { get; set; }
    
    }
}
