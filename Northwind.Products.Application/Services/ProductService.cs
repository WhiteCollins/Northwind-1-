﻿using Microsoft.Extensions.Logging;
using Northwind.Products.Application.Contracts;
using Northwind.Products.Application.Core;
using Northwind.Products.Application.Dtos;
using Northwind.Products.Application.Extensions;
using Northwind.Products.Domain.Interface;


namespace Northwind.Products.Application.Services
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
                        ProductID = product.ProductID,
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
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        public ServiceResult GetProductById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var product = (from p in productRepository.GetAll()
                               where p.ProductID == id
                               select new ProductDtoGetAll()
                               {
                                   ProductID = p.ProductID,
                                   UnitPrice = (decimal)p.UnitPrice,
                                   ProductName = p.ProductName
                               }).FirstOrDefault();

                if (product == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el producto con ID: {id}.";
                }
                else
                {
                    result.Result = product;
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto.";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        public ServiceResult RemoveProduct(ProductDtoRemove? productDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (productDtoRemove == null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(productDtoRemove)} es requerido.";
                    return result;
                }

                var product = new Domain.Entities.Product()
                {
                    ProductID = productDtoRemove.ProductID,
                };

                this.productRepository.Remove(product);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo el producto.";
                this.logger.LogError(ex, result.Message);
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

                var product = new Domain.Entities.Product()
                {
                    CategoryID = productDtoSave.CategoryID,
                    SupplierID = productDtoSave.SupplierID,
                    ProductName = productDtoSave.ProductName,
                    UnitPrice = productDtoSave.UnitPrice,
                };

                this.productRepository.Save(product);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el producto.";
                this.logger.LogError(ex, result.Message);
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

                var product = new Domain.Entities.Product()
                {
                    CategoryID = productDtoUpdate.CategoryID,
                    SupplierID = productDtoUpdate.SupplierID,
                    ProductName = productDtoUpdate.ProductName,
                    ProductID = productDtoUpdate.ProductID,
                    UnitPrice = productDtoUpdate.UnitPrice,
                };

                this.productRepository.Update(product);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el producto.";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        // Métodos asincrónicos implementados de manera básica
        public async Task<ServiceResult> GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var products = await Task.Run(() => productRepository.GetAll());
                result.Result = products.Select(p => new ProductDtoGetAll
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    UnitPrice = (decimal)p.UnitPrice,
                    SupplierID = p.SupplierID,
                    CategoryID = p.CategoryID
                }).ToList();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos.";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<ServiceResult> GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var product = await Task.Run(() => productRepository.GetEntityBy(id));

                if (product == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el producto con ID: {id}.";
                }
                else
                {
                    result.Result = new ProductDtoGetAll
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        UnitPrice = (decimal)product.UnitPrice,
                        SupplierID = product.SupplierID,
                        CategoryID = product.CategoryID
                    };
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto.";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<ServiceResult> Add(ProductDtoBase productDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var product = new Domain.Entities.Product
                {
                    ProductName = productDto.ProductName,
                    UnitPrice = productDto.UnitPrice,
                    SupplierID = productDto.SupplierID,
                    CategoryID = productDto.CategoryID
                };

                await Task.Run(() => this.productRepository.Save(product));
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error agregando el producto.";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<ServiceResult> Update(ProductDtoBase productDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var product = new Domain.Entities.Product
                {
                    ProductID = productDto.ProductID,
                    ProductName = productDto.ProductName,
                    UnitPrice = productDto.UnitPrice,
                    SupplierID = productDto.SupplierID,
                    CategoryID = productDto.CategoryID
                };

                await Task.Run(() => this.productRepository.Update(product));
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el producto.";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<ServiceResult> Remove(ProductDtoRemove productDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var product = new Domain.Entities.Product
                {
                    ProductID = productDto.ProductID
                };

                await Task.Run(() => this.productRepository.Remove(product));
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo el producto.";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        // Métodos sin implementar de la interfaz IProductService
        ServiceResult IProductService.GetAll()
        {
            return GetAll().Result;
        }

        ServiceResult IProductService.GetById(int id)
        {
            return GetById(id).Result;
        }

        ServiceResult IProductService.Add(ProductDtoBase product)
        {
            return Add(product).Result;
        }

        ServiceResult IProductService.Update(ProductDtoBase product)
        {
            return Update(product).Result;
        }

        ServiceResult IProductService.Remove(ProductDtoRemove product)
        {
            return Remove(product).Result;
        }
    }
}
