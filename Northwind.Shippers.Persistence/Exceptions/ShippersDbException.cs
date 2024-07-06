using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Shippers.Persistence.Exceptions
{
    public class ShippersDbException: Exception
    {
        public ShippersDbException(string message) : base(message) { }
    }
}
