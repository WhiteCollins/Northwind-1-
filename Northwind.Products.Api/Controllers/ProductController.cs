﻿using Microsoft.AspNetCore.Mvc;
using Northwind.Products.Application.Contracts;
using Northwind.Products.Application.Dtos;

namespace Northwind.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetProducts")]
        public IActionResult Get()
        {
            var result = this.productService.GetAll();
            if (!result.Success) // Corrigiendo la lógica del if
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpGet("GetProductById")]
        public IActionResult Get(int id)
        {
            var result = this.productService.GetById(id);
            if (!result.Success) // Corrigiendo la lógica del if
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost("SaveProducts")]
        public IActionResult Post([FromBody] ProductDtoSave productDtoSave)
        {
            var result = this.productService.Add(productDtoSave);
            if (!result.Success) // Corrigiendo la lógica del if
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost("UpdateProduct")]
        public IActionResult Put([FromBody] ProductDtoUpdate productDtoUpdate)
        {
            var result = this.productService.Update(productDtoUpdate);
            if (!result.Success) // Corrigiendo la lógica del if
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpDelete("RemoveProducts")]
        public IActionResult Delete([FromBody] ProductDtoRemove productDtoRemove)
        {
            var result = this.productService.Remove(productDtoRemove);
            if (!result.Success) // Corrigiendo la lógica del if
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
