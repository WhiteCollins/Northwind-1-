using Microsoft.Extensions.Logging;
using Northwind.Shippers.Application.Contracts;
using Northwind.Shippers.Application.Dtos;
using Northwind.Shippers.Application.Base;
using Northwind.Shippers.Domain.Interface;
using Northwind.Shippers.Application.Extentions;
using Northwind.Shippers.Domain.Entities;

namespace Northwind.Shippers.Application.Services
{
    public class ShipperService : IShippersService
    {
        private readonly IShippersRepository shippersRepository;
        private readonly ILogger<ShipperService> logger;

        public ShipperService(IShippersRepository shipperRepository,
                               ILogger<ShipperService> logger)
        {
            this.shippersRepository = shipperRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var shippers = this.shippersRepository.GetAll();

                result.Result = (from shipper in shippers
                                 select new ShippersDtoGetAll()
                                 {
                                     ShipperID = shipper.Id,
                                     CompanyName = shipper.CompanyName,
                                     Phone = shipper.Phone
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
                var shipper = this.shippersRepository.GetEntityBy(id);

                if (shipper == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el transportista con ID: {id}.";
                }
                else
                {
                    result.Result = new ShippersDtoGetAll()
                    {
                        ShipperID = shipper.Id,
                        CompanyName = shipper.CompanyName,
                        Phone = shipper.Phone,
                    };
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el transportista.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Add(ShippersDtoBase shipperDtoBase)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = shipperDtoBase.IsValidShippers();

                if (!result.Success)
                    return result;

                var shipper = new Domain.Entities.Shippers()
                {
                    CompanyName = shipperDtoBase.CompanyName,
                    Phone = shipperDtoBase.Phone,
                };

                this.shippersRepository.Save(shipper);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el transportista.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(ShippersDtoBase shippersDtoBase)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = shippersDtoBase.IsValidShippers();

                if (!result.Success)
                    return result;

                var shipper = new Domain.Entities.Shippers()
                {
                    Id = shippersDtoBase.ShipperID ,
                    CompanyName = shippersDtoBase.CompanyName,
                    Phone = shippersDtoBase.Phone,
                };

                this.shippersRepository.Update(shipper);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el transportista.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(ShippersDtoRemove shipperDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (shipperDtoRemove == null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(shipperDtoRemove)} es requerido.";
                    return result;
                }

                var shipper = new Domain.Entities.Shippers()
                {
                    Id = shipperDtoRemove.ShipperID,
                };

                this.shippersRepository.Remove(shipper);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo el transportista.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
