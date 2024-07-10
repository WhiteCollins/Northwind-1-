using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Products.Application.Core
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Success = true;
        }
        public string? Message { get; set; }
        public bool Success { get; set; }
        public dynamic? Result { get; set; } = null;
    }
}
