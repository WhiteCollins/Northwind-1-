using Microsoft.Extensions.Logging;
using Northwind.Products.Domain.Interface;
using Northwind.Products.Domain.Entities;
using Northwind.Products.Application.Contracts;
using Northwind.Products.Application.Core;
using Northwind.Products.Application.Dtos;
using Northwind.Products.Application.Extensions;

namespace Northwind.Products.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ILogger<ProductService> logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            this.productRepository = productRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var products = this.productRepository.GetAll();

                result.Result = (from product in products
                                 select new ProductDtoGetAll()
                                 {
                                     ProductID = product.ProductID,
                                     ProductName = product.ProductName,
                                     Discontinued = product.Discontinued
                                 }).ToList();

                result.Success = true;
                result.Message = "Products successfully obtained.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtaining products.";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var product = this.productRepository.GetEntityBy(id);

                if (product == null)
                {
                    result.Success = false;
                    result.Message = $"No product found with ID: {id}.";
                }
                else
                {
                    result.Result = new ProductDtoGetAll()
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        SupplierID = product.SupplierID,
                        CategoryID = product.CategoryID,
                        UnitPrice = product.UnitPrice,
                        UnitsInStock = product.UnitsInStock,
                        UnitsOnOrder = product.UnitsOnOrder,
                        ReorderLevel = product.ReorderLevel,
                        Discontinued = product.Discontinued
                    };
                    result.Success = true;
                    result.Message = "Product successfully obtained.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtaining the product.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Add(ProductDtoSave productDtoSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = productDtoSave.IsValidProduct();

                if (!result.Success)
                    return result;

                var product = new Product()
                {
                    ProductName = productDtoSave.ProductName,
                    SupplierID = productDtoSave.SupplierID,
                    CategoryID = productDtoSave.CategoryID,
                    UnitPrice = productDtoSave.UnitPrice,
                    UnitsInStock = productDtoSave.UnitsInStock,
                    UnitsOnOrder = productDtoSave.UnitsOnOrder,
                    ReorderLevel = productDtoSave.ReorderLevel,
                    Discontinued = productDtoSave.Discontinued
                };

                this.productRepository.Save(product);
                result.Success = true;
                result.Message = "Product successfully added.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error saving the product.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Update(ProductDtoUpdate productDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = productDtoUpdate.IsValidProduct();

                if (!result.Success)
                    return result;

                var product = new Product()
                {
                    ProductID = productDtoUpdate.ProductID,
                    ProductName = productDtoUpdate.ProductName,
                    SupplierID = productDtoUpdate.SupplierID,
                    CategoryID = productDtoUpdate.CategoryID,
                    UnitPrice = productDtoUpdate.UnitPrice,
                    UnitsInStock = productDtoUpdate.UnitsInStock,
                    UnitsOnOrder = productDtoUpdate.UnitsOnOrder,
                    ReorderLevel = productDtoUpdate.ReorderLevel,
                    Discontinued = productDtoUpdate.Discontinued
                };

                this.productRepository.Update(product);
                result.Success = true;
                result.Message = "Product successfully updated.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error updating the product.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Remove(ProductDtoRemove productDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (productDtoRemove == null)
                {
                    result.Success = false;
                    result.Message = $"The object {nameof(productDtoRemove)} is required.";
                    return result;
                }

                var product = new Product()
                {
                    ProductID = productDtoRemove.ProductID
                };

                this.productRepository.Remove(product);
                result.Success = true;
                result.Message = "Product successfully removed.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removing the product.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }
    }
}
