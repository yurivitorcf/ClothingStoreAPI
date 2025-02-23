using ClothingStore.Application.DTOs;
using ClothingStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Application.Interfaces;

namespace ClothingStore.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all-products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost("new-product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (productDto == null)
                return BadRequest("Product data cannot be null");

            await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProducts), new {id = productDto.Name}, productDto);
        }

        [HttpGet("findById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPut("update-product/{id}")]

        public async Task<IActionResult> UpdateProduct(int id,[FromBody] UpdateProductDto productDto)
        {
            if (productDto == null)
                return BadRequest("Product data is null");

            await _productService.UpdateProductAsync(id, productDto);
            return NoContent();
             
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
        
    }
}
