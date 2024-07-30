using Northwind.Common.Data.Repository;

namespace Northwind.Shippers.Domain.Interface
{
    public interface IShippersRepository : IBaseRepository<Shippers.Domain.Entities.Shippers, int>
    {
        List<Shippers.Domain.Entities.Shippers> GetShippers();
    }
}
