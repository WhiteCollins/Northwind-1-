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
            if (baseSupplier?.CompanyName.Length > 40)
            {
                result.Success = false;
                result.Message = $"El nombre de la compañía no puede ser mayor a 40 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(baseSupplier?.ContactName))
            {
                result.Success = false;
                result.Message = $"El nombre de contacto es requerido.";
                return result;
            }
            if (baseSupplier?.ContactName.Length > 30)
            {
                result.Success = false;
                result.Message = $"El nombre de contacto no puede ser mayor a 30 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(baseSupplier?.ContactTitle))
            {
                result.Success = false;
                result.Message = $"El título de contacto es requerido.";
                return result;
            }
            if (baseSupplier?.ContactTitle.Length > 30)
            {
                result.Success = false;
                result.Message = $"El título de contacto no puede ser mayor a 30 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(baseSupplier?.Address))
            {
                result.Success = false;
                result.Message = $"La dirección es requerida.";
                return result;
            }
            if (baseSupplier?.Address.Length > 60)
            {
                result.Success = false;
                result.Message = $"La dirección no puede ser mayor a 60 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(baseSupplier?.City))
            {
                result.Success = false;
                result.Message = $"La ciudad es requerida.";
                return result;
            }
            if (baseSupplier?.City.Length > 15)
            {
                result.Success = false;
                result.Message = $"La ciudad no puede ser mayor a 15 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(baseSupplier?.Region))
            {
                result.Success = false;
                result.Message = $"La región es requerida.";
                return result;
            }
            if (baseSupplier?.Region.Length > 15)
            {
                result.Success = false;
                result.Message = $"La región no puede ser mayor a 15 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(baseSupplier?.PostalCode))
            {
                result.Success = false;
                result.Message = $"El código postal es requerido.";
                return result;
            }
            if (baseSupplier?.PostalCode.Length > 10)
            {
                result.Success = false;
                result.Message = $"El código postal no puede ser mayor a 10 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(baseSupplier?.Country))
            {
                result.Success = false;
                result.Message = $"El país es requerido.";
                return result;
            }
            if (baseSupplier?.Country.Length > 15)
            {
                result.Success = false;
                result.Message = $"El país no puede ser mayor a 15 caracteres.";
                return result;
            }

            if (string.IsNullOrEmpty(baseSupplier?.Phone))
            {
                result.Success = false;
                result.Message = $"El número de teléfono es requerido.";
                return result;
            }
            if (baseSupplier?.Phone.Length == 0)
            {
                result.Success = false;
                result.Message = $"El número de teléfono no puede ser cero.";
                return result;
            }
            if (baseSupplier?.Phone.Length > 24)
            {
                result.Success = false;
                result.Message = $"El número de teléfono no puede ser mayor a 24 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(baseSupplier?.Fax))
            {
                result.Success = false;
                result.Message = $"El número de fax es requerido.";
                return result;
            }
            if (baseSupplier?.Fax.Length == 0)
            {
                result.Success = false;
                result.Message = $"El número de fax no puede ser cero.";
                return result;
            }
            if (baseSupplier?.Fax.Length > 24)
            {
                result.Success = false;
                result.Message = $"El número de fax no puede ser mayor a 24 caracteres.";
                return result;
            }
            if (string.IsNullOrEmpty(baseSupplier?.HomePage))
            {
                result.Success = false;
                result.Message = $"La página de inicio es requerida.";
                return result;
            }
            if (baseSupplier?.HomePage.Length > 40)
            {
                result.Success = false;
                result.Message = $"La página de inicio no puede ser mayor a 40 caracteres.";
                return result;
                }

                return result;
            }
        }
    }
