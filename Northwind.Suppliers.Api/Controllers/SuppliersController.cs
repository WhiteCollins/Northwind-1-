using Microsoft.AspNetCore.Mvc;
using Northwind.Suppliers.Application.Contracts;
using Northwind.Suppliers.Application.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Suppliers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService supplierService;

        public SuppliersController(ISuppliersService supplierService)
        {
            this.supplierService=supplierService;
        }


        // GET: api/<SuppliersController>
        [HttpGet("GetSuppliers")]
        public IActionResult Get()
        {
            var result = this.supplierService.GetAll();
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // GET api/<SuppliersController>/5
        [HttpGet("GetSuppliersByid")]
        public IActionResult Get(int id)
        {
            var result = this.supplierService.GetById(id);
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // POST api/<SuppliersController>
        [HttpPost("SaveSuppliers")]
        public void Post([FromBody] Suppliers.Application.Dtos.SuppliersDtoSave suppliersDtoSave)
        {
            var result = this.supplierService.Add(suppliersDtoSave);
            if (result.Success)
                BadRequest(result);
            else
                Ok(result);
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("UpdateSuppliers")]
        public IActionResult Put(SuppliersDtoUpdate suppliersDtoUpdate)
        {
            var result = this.supplierService.Update(suppliersDtoUpdate);
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("RemoveSuppliers")]
        public IActionResult Delete(SuppliersDtoRemove suppliersDtoRemove)
        {
            var result = this.supplierService.Remove(suppliersDtoRemove);
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
