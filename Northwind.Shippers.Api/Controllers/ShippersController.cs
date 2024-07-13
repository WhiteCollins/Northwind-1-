using Microsoft.AspNetCore.Mvc;
using Northwind.Shippers.Application.Contracts;
using Northwind.Shippers.Application.Dtos;
using Northwind.Shippers.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Shippers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShippersService shipperService;

        public ShippersController(IShippersService shipperService)
        {
            this.shipperService=shipperService = shipperService ?? throw new ArgumentNullException(nameof(shipperService));
        }


        // GET: api/<ShippersController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.shipperService.GetAll();
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        // GET api/<ShippersController>/5
        [HttpGet("GetShippersByid")]
        public IActionResult Get(int id)
        {
            var result = this.shipperService.GetById(id);
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // POST api/<ShippersController>
        [HttpPost("SaveShippers")]
        public void Post([FromBody] Shippers.Application.Dtos.ShippersDtoSave  shippersDtoSave)
        {
            var result = this.shipperService.Add(shippersDtoSave);
            if (result.Success)
                BadRequest(result);
            else
                Ok(result);
        }

        // PUT api/<ShippersController>/5
        [HttpPut("UpdateProducts")]
        public IActionResult Put(ShippersDtoUpdate shippersDtoUpdate)
        {
            var result = this.shipperService.Update(shippersDtoUpdate);
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // DELETE api/<ShippersController>/5
        [HttpDelete("RemoveShippers")]
        public IActionResult Delete(ShippersDtoRemove shippersDtoRemove)
        {
                var result = this.shipperService.Remove(shippersDtoRemove);
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
