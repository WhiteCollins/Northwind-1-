using Microsoft.AspNetCore.Mvc;
using Northwind.Suppliers.Application.Dtos;

namespace Northwind.Suppliers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService supplierService;

        public SuppliersController(ISuppliersService supplierService)
        {
            this.supplierService = supplierService;
        }

        // GET: api/<SuppliersController>
        [HttpGet("GetSuppliers")]
        public IActionResult Get()
        {
            var result = this.supplierService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // GET api/<SuppliersController>/5
        [HttpGet("GetSuppliersByid/{id}")]
        public IActionResult Get(int id)
        {
            var result = this.supplierService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // POST api/<SuppliersController>
        [HttpPost("SaveSuppliers")]
        public IActionResult Post([FromBody] SuppliersDtoSave suppliersDtoSave)
        {
            var result = this.supplierService.Add(suppliersDtoSave);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // PUT api/<SuppliersController>
        [HttpPut("UpdateSuppliers")]
        public IActionResult Put( SuppliersDtoUpdate suppliersDtoUpdate)
        {
            var result = this.supplierService.Update(suppliersDtoUpdate);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // DELETE api/<SuppliersController>
        [HttpDelete("RemoveSuppliers")]
        public IActionResult Delete( SuppliersDtoRemove suppliersDtoRemove)
        {
            var result = this.supplierService.Remove(suppliersDtoRemove);
            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
