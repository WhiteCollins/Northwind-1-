
using Microsoft.Extensions.Logging;
using Northwind.Products.Application.Contracts;
using Northwind.Products.Application.Core;
using Northwind.Products.Application.Dtos;
using Northwind.Products.Application.Extentions;
using Northwind.Products.Domain.Interface;
using Northwind.Suppliers.Domain.Entities;


namespace Northwind.Products.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ILogger<ProductService> logger;

        public ProductService(IProductRepository productRepository,
                             ILogger<ProductService> logger)
        {
            this.productRepository = productRepository;
            this.logger = logger;
        }

        public ServiceResult GetProduct(int productId)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var product = this.productRepository.GetEntityBy(productId);

                if (product == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el producto con ID: {productId}.";
                }
                else
                {
                    result.Result = new ProductDtoGetAll()
                    {
                        ProductID = product.Id,
                        ProductName = product.ProductName,
                        UnitPrice = (decimal)product.UnitPrice,
                        SupplierID = product.SupplierID,
                        CategoryID = product.CategoryID,

                    };
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }


        public ServiceResult GetProductById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Result = (from product in productRepository.GetAll()
                                 where product.Id == id
                                 select new ProductDtoGetAll()
                                 {
                                     ProductID = product.Id,
                                     UnitPrice = (decimal)product.UnitPrice,
                                     ProductName = product.ProductName
                                 }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult RemoveProduct(ProductDtoRemove? productDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (productDtoRemove is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(productDtoRemove)} es requerido.";
                    return result;
                }

                Domain.Entities.Product product = new Domain.Entities.Product()
                {
                    ProductID = productDtoRemove.ProductID,
                };

                this.productRepository.Remove(product);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo el producto.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult SaveProduct(ProductDtoSave? productDtoSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = productDtoSave.IsValidProduct();

                if (!result.Success)
                    return result;

                Domain.Entities.Product product = new Domain.Entities.Product()
                {
                    CategoryID = productDtoSave.CategoryID,
                    SupplierID = productDtoSave.SupplierID,
                    ProductName = productDtoSave.ProductName,
                    UnitPrice = productDtoSave.UnitPrice,
                };

                this.productRepository.Save(product);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el producto.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult UpdateProduct(ProductDtoUpdate productDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = productDtoUpdate.IsValidProduct();

                if (!result.Success)
                    return result;

                Domain.Entities.Product product = new Domain.Entities.Product()
                {
                    CategoryID = productDtoUpdate.CategoryID,
                    SupplierID = productDtoUpdate.SupplierID,
                    ProductName = productDtoUpdate.ProductName,
                    ProductID = productDtoUpdate.ProductID,
                    UnitPrice = productDtoUpdate.UnitPrice,
                };

                this.productRepository.Update(product);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el producto.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public Task<ServiceResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Add(ProductDtoBase product)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Update(ProductDtoBase product)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Remove(ProductDtoRemove product)
        {
            throw new NotImplementedException();
        }

        ServiceResult IProductService.GetAll()
        {
            throw new NotImplementedException();
        }

        ServiceResult IProductService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        ServiceResult IProductService.Add(ProductDtoBase product)
        {
            throw new NotImplementedException();
        }

        ServiceResult IProductService.Update(ProductDtoBase product)
        {
            throw new NotImplementedException();
        }

        ServiceResult IProductService.Remove(ProductDtoRemove product)
        {
            throw new NotImplementedException();
        }
    }
}
