using Northwind.Suppliers.Application.Base;
using Northwind.Suppliers.Application.Dtos;

namespace Northwind.Suppliers.Application.Extentions
{
    public static class ValidateSupplier
    {
        public static ServiceResult IsValidSuppliers(this SuppliersDtoBase baseSupplier)
        {
            ServiceResult result = new ServiceResult();

            if (baseSupplier is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseSupplier)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseSupplier?.CompanyName))
            {
                result.Success = false;
                result.Message = $"El nombre de la compañía es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseSupplier?.Phone))
            {
                result.Success = false;
                result.Message = $"El número de teléfono es requerido.";
                return result;
            }
            return result;
        }
    }
}
