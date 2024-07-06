using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Suppliers.Application.Base
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Sucsses = true;
        }


        public string? message { get; set; }
        public bool Sucsses { get; set; }
        public dynamic? Result { get; set; } = null;
    }
}
