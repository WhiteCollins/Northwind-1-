using Northwind.Shippers.Application.Base;
using Northwind.Shippers.Application.Dtos;

namespace Northwind.Shippers.Application.Contracts
{
    public interface IShippersService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
        ServiceResult Add(ShippersDtoBase shippers);
        ServiceResult Update(ShippersDtoBase shippers);
        ServiceResult Remove(ShippersDtoRemove shippers);
    }
}
