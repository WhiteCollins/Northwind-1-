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
            if (baseProduct?.UnitsInStock == 0 || baseProduct?.UnitsInStock < 0)
            {
                result.Success = false;
                result.Message = $"La cantidad de unidades en stock no puede ser cero o negativo.";
                return result;
            }
            if (baseProduct?.UnitsOnOrder == 0 || baseProduct?.UnitsOnOrder < 0)
            {
                result.Success = false;
                result.Message = $"La cantidad de unidades en orden no puede ser cero o negativo.";
                return result;
            }
            if (baseProduct?.ReorderLevel == 0 || baseProduct?.ReorderLevel < 0)
            {
                result.Success = false;
                result.Message = $"El nivel de reorden no puede ser cero o negativo.";
                return result;
            }
            if (baseProduct?.SupplierID == 0 || baseProduct?.SupplierID < 0)
            {
                result.Success = false;
                result.Message = $"El ID del proveedor no puede ser cero o negativo.";
                return result;
            }
            if (baseProduct?.CategoryID == 0 || baseProduct?.CategoryID < 0)
            {
                result.Success = false;
                result.Message = $"El ID de la categoría no puede ser cero o negativo.";
                return result;
            }
          
            result.Success = true;
            result.Message = "El producto es válido.";
            return result;
        }
    }
}
