using Northwind.Products.Application.Core;
using Northwind.Products.Application.Dtos;

namespace Northwind.Products.Application.Extensions
{
    public static class ValidateProduct
    {
        public static ServiceResult IsValidProduct(this ProductDtoBase baseProduct)
        {
            ServiceResult result = new ServiceResult();

            if (baseProduct is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseProduct)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseProduct?.ProductName))
            {
                result.Success = false;
                result.Message = $"El nombre del producto es requerido.";
                return result;
            }

            if (baseProduct?.UnitPrice == 0 || baseProduct?.UnitPrice < 0)
            {
                result.Success = false;
                result.Message = $"El precio del producto no puede ser cero o negativo.";
                return result;
            }

            if (baseProduct?.CategoryID == 0)
            {
                result.Success = false;
                result.Message = $"Debe seleccionar la categoría a la que pertenece el producto.";
                return result;
            }

            if (baseProduct?.SupplierID == 0)
            {
                result.Success = false;
                result.Message = $"Debe seleccionar el proveedor del producto.";
                return result;
            }

            // If all validations pass
            result.Success = true;
            result.Message = "El producto es válido.";
            return result;
        }
    }
}
