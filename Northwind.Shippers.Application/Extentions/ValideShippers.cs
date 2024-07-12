using Northwind.Shippers.Application.Base;
using Northwind.Shippers.Application.Dtos;

namespace Northwind.Shippers.Application.Extentions
{
    public static class ValidateShipper
    {
        public static ServiceResult IsValidShippers(this ShippersDtoBase baseShipper)
        {
            ServiceResult result = new ServiceResult();

            if (baseShipper is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseShipper)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseShipper?.CompanyName))
            {
                result.Success = false;
                result.Message = $"El nombre de la compañía es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseShipper?.Phone))
            {
                result.Success = false;
                result.Message = $"El número de teléfono es requerido.";
                return result;
            }

            return result;
        }
    }
}
