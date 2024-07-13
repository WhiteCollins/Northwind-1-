using Microsoft.Extensions.Logging;
using Northwind.Suppliers.Application.Contracts;
using Northwind.Suppliers.Application.Dtos;
using Northwind.Suppliers.Application.Base;
using Northwind.Suppliers.Domain.Interface;
using Northwind.Suppliers.Application.Extentions;

namespace Northwind.Suppliers.Application.Services
{
    public class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository suppliersRepository;
        private readonly ILogger<SuppliersService> logger;

        public SuppliersService(ISuppliersRepository suppliersRepository,
                                ILogger<SuppliersService> logger)
        {
            this.suppliersRepository = suppliersRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var suppliers = this.suppliersRepository.GetAll();

                result.Result = (from supplier in suppliers
                                 select new SuppliersDtoGetAll()
                                 {
                                     SupplierID = supplier.Id,
                                     CompanyName = supplier.CompanyName,
                                     ContactName = supplier.ContactName,
                                     ContactTitle = supplier.ContactTitle,
                                     Address = supplier.Address,
                                     City = supplier.City,
                                     Region = supplier.Region,
                                     PostalCode = supplier.PostalCode,
                                     Country = supplier.Country,
                                     Phone = supplier.Phone,
                                     Fax = supplier.Fax,
                                     HomePage = supplier.HomePage
                                 }).ToList();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var supplier = this.suppliersRepository.GetEntityBy(id);

                if (supplier == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el proveedor con ID: {id}.";
                }
                else
                {
                    result.Result = new SuppliersDtoGetAll()
                    {
                        SupplierID = supplier.Id,
                        CompanyName = supplier.CompanyName,
                        ContactName = supplier.ContactName,
                        ContactTitle = supplier.ContactTitle,
                        Address = supplier.Address,
                        City = supplier.City,
                        Region = supplier.Region,
                        PostalCode = supplier.PostalCode,
                        Country = supplier.Country,
                        Phone = supplier.Phone,
                        Fax = supplier.Fax,
                        HomePage = supplier.HomePage
                    };
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el proveedor.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Add(SuppliersDtoBase supplierDtoBase)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = supplierDtoBase.IsValidSuppliers();

                if (!result.Success)
                    return result;

                var supplier = new Domain.Entities.Suppliers()
                {
                    CompanyName = supplierDtoBase.CompanyName,
                    ContactName = supplierDtoBase.ContactName,
                    ContactTitle = supplierDtoBase.ContactTitle,
                    Address = supplierDtoBase.Address,
                    City = supplierDtoBase.City,
                    Region = supplierDtoBase.Region,
                    PostalCode = supplierDtoBase.PostalCode,
                    Country = supplierDtoBase.Country,
                    Phone = supplierDtoBase.Phone,
                    Fax = supplierDtoBase.Fax,
                    HomePage = supplierDtoBase.HomePage
                };

                this.suppliersRepository.Save(supplier);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el proveedor.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(SuppliersDtoBase suppliersDtoBase)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = suppliersDtoBase.IsValidSuppliers();

                if (!result.Success)
                    return result;

                var supplier = new Domain.Entities.Suppliers()
                {
                    Id = suppliersDtoBase.SupplierID,
                    CompanyName = suppliersDtoBase.CompanyName,
                    ContactName = suppliersDtoBase.ContactName,
                    ContactTitle = suppliersDtoBase.ContactTitle,
                    Address = suppliersDtoBase.Address,
                    City = suppliersDtoBase.City,
                    Region = suppliersDtoBase.Region,
                    PostalCode = suppliersDtoBase.PostalCode,
                    Country = suppliersDtoBase.Country,
                    Phone = suppliersDtoBase.Phone,
                    Fax = suppliersDtoBase.Fax,
                    HomePage = suppliersDtoBase.HomePage
                };

                this.suppliersRepository.Update(supplier);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el proveedor.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(SuppliersDtoRemove supplierDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (supplierDtoRemove == null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(supplierDtoRemove)} es requerido.";
                    return result;
                }

                var supplier = new Domain.Entities.Suppliers()
                {
                    Id = supplierDtoRemove.SupplierID
                };

                this.suppliersRepository.Remove(supplier);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo el proveedor.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
