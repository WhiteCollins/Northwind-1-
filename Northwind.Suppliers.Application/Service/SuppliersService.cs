using Microsoft.Extensions.Logging;
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
            var result = new ServiceResult();
            try
            {
                var suppliers = this.suppliersRepository.GetAll();

                result.Result = (from supplier in suppliers
                                 select new SuppliersDtoBase()
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
                result.Message = "Proveedores obtenidos exitosamente.";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error obteniendo proveedores.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            var result = new ServiceResult();

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
                    result.Message = "Proveedor obtenido exitosamente.";
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error obteniendo el proveedor.");
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ServiceResult Add(SuppliersDtoSave suppliersDtoSave)
        {
            var result = new ServiceResult();

            try
            {
                var validationResult = suppliersDtoSave.IsValidSuppliers();
                if (!validationResult.Success)
                    return validationResult;

                var supplier = new Domain.Entities.Suppliers()
                {
                    CompanyName = suppliersDtoSave.CompanyName,
                    ContactName = suppliersDtoSave.ContactName,
                    ContactTitle = suppliersDtoSave.ContactTitle,
                    Address = suppliersDtoSave.Address,
                    City = suppliersDtoSave.City,
                    Region = suppliersDtoSave.Region,
                    PostalCode = suppliersDtoSave.PostalCode,
                    Country = suppliersDtoSave.Country,
                    Phone = suppliersDtoSave.Phone,
                    Fax = suppliersDtoSave.Fax,
                    HomePage = suppliersDtoSave.HomePage
                };

                this.suppliersRepository.Save(supplier);
                result.Result = supplier;
                result.Success = true;
                result.Message = "Proveedor guardado exitosamente.";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error guardando el proveedor.");
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ServiceResult Update(SuppliersDtoUpdate suppliersDtoUpdate)
        {
            var result = new ServiceResult();

            try
            {
                var validationResult = suppliersDtoUpdate.IsValidSuppliers();
                if (!validationResult.Success)
                    return validationResult;

                var supplier = this.suppliersRepository.GetEntityBy(suppliersDtoUpdate.SupplierID);
                if (supplier == null)
                {
                    result.Success = false;
                    result.Message = "Proveedor no encontrado.";
                    return result;
                }

                supplier.CompanyName = suppliersDtoUpdate.CompanyName;
                supplier.ContactName = suppliersDtoUpdate.ContactName;
                supplier.ContactTitle = suppliersDtoUpdate.ContactTitle;
                supplier.Address = suppliersDtoUpdate.Address;
                supplier.City = suppliersDtoUpdate.City;
                supplier.Region = suppliersDtoUpdate.Region;
                supplier.PostalCode = suppliersDtoUpdate.PostalCode;
                supplier.Country = suppliersDtoUpdate.Country;
                supplier.Phone = suppliersDtoUpdate.Phone;
                supplier.Fax = suppliersDtoUpdate.Fax;
                supplier.HomePage = suppliersDtoUpdate.HomePage;

                this.suppliersRepository.Update(supplier);
                result.Result = supplier;
                result.Success = true;
                result.Message = "Proveedor actualizado exitosamente.";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error actualizando el proveedor.");
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ServiceResult Remove(SuppliersDtoRemove suppliersDtoRemove)
        {
            var result = new ServiceResult();

            try
            {
                var supplier = this.suppliersRepository.GetEntityBy(suppliersDtoRemove.SupplierID);
                if (supplier == null)
                {
                    result.Success = false;
                    result.Message = "Proveedor no encontrado.";
                    return result;
                }

                this.suppliersRepository.Remove(supplier);
                result.Success = true;
                result.Message = "Proveedor eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error eliminando el proveedor.");
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
