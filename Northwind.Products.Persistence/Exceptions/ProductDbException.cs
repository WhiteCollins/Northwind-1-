

namespace Northwind.Products.Persistence.Exceptions
{
    public class ProductDbException : Exception
    {
        public ProductDbException(string message) : base(message)
        {
        }
    }
}
