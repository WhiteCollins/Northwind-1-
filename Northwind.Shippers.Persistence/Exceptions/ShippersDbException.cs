namespace Northwind.Shippers.Persistence.Exceptions
{
    public class ShippersDbException : Exception
    {
        public ShippersDbException(string message) : base(message) { }
    }
}
