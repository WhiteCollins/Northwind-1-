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
            if (baseShipper?.Phone.Length == 0)
            {
                result.Success = false;
                result.Message = $"El número de teléfono no puede ser cero.";
                return result;
            }
            if (baseShipper?.Phone.Length > 24)
            {
                result.Success = false;
                result.Message = $"El número de teléfono no puede ser mayor a 24 caracteres.";
                return result;
            } if(baseShipper?.Phone.Length < 8)

            {
                result.Success = false;
                result.Message = $"El número de teléfono no puede ser menor a 8 caracteres.";
                return result;
            }
            if (baseShipper?.CompanyName.Length > 40)
            {
                result.Success = false;
                result.Message = $"El nombre de la empresa no puede ser mayor a 40 caracteres.";
                return result;
            }

            return result;
        }
    }
}
