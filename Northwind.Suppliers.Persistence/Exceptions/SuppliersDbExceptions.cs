using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Suppliers.Persistence.Exceptions
{
    public class SuppliersDbExceptions: Exception
    {
        public SuppliersDbExceptions(string message) : base(message) { }
    }
}
