using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Products.Persistence.Exceptions
{
    public class ProductDbException : Exception
    {
        public ProductDbException(string message) : base(message)
        {
        }
    }
}
