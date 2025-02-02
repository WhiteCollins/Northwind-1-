﻿using Northwind.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Shippers.Domain.Entities
{
    public class Shippers : AuditEntity<int>
    {
        [Column("ShippersID")]
        public override int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
