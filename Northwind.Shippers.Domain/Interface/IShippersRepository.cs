using Northwind.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Shippers.Domain.Interface
{
    public interface IShippersRepository: IBaseRepository<Shippers.Domain.Entities.Shippers,int>
    {
        List<Shippers.Domain.Entities.Shippers> GetShippers();
    }
}
