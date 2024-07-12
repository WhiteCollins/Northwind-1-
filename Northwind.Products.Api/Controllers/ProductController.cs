using Microsoft.AspNetCore.Mvc;
using Northwind.Products.Application.Contracts;
using Northwind.Products.Application.Dtos;
using Northwind.Products.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService=productService;
        }

        [HttpGet("GetProducts")]
        public IActionResult Get()
        {
            var result = this.productService.GetAll();
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);

        }

        [HttpGet("GetProductByid")]
        public IActionResult Get(int id)
        {
            var result = this.productService.GetById(id);
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost("SaveProducts")]
        public void Post([FromBody] Products.Application.Dtos.ProductDtoSave productDtoSave)
        {
            var result = this.productService.Add(productDtoSave);
            if (result.Success)
                BadRequest(result);
            else
                Ok(result);
        }

        [HttpPost("UpdatePorduct")]
        public IActionResult Put(ProductDtoUpdate productDtoUpdate)
        {
            var result = this.productService.Update(productDtoUpdate);
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);

        }

        [HttpDelete("RemoveProducts")]
        public IActionResult Delete(ProductDtoRemove productDtoRemove)
        {
            var result = this.productService.Remove(productDtoRemove);
            if (result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
