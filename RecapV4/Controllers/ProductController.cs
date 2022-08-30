using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecapV4.Models.DTOs;
using RecapV4.Repositories;

namespace RecapV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public ProductController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = _repository.Product.GetAll();
            return Ok(products);
        }

        [HttpGet("id/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.Product.GetById(id);
            return Ok(product);
        }

        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetByBarcode(string barcode)
        {
            var products = await _repository.Product.GetByBarcode(barcode);
            return Ok(products);
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var products = await _repository.Product.GetByCategory(category);
            return Ok(products);
        }

        [HttpGet("subcategory/{subcategory}")]
        public async Task<IActionResult> GetBySubcategory(string subcategory)
        {
            var products = await _repository.Product.GetBySubcategory(subcategory);
            return Ok(products);
        }

        [HttpGet("size/{size}")]
        public async Task<IActionResult> GetBySize(string size)
        {
            var product = await _repository.Product.GetBySize(size);
            return Ok(product);
        }

        [HttpGet("color{color}")]
        public async Task<IActionResult> GetByColor(string color)
        {
            var products = await _repository.Product.GetByColor(color);
            return Ok(products);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO dto)
        {
            _repository.Product.UpdateProduct(id, dto);

            await _repository.SaveAsync();

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            _repository.Product.DeleteProduct(id);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO dto)
        {
            _repository.Product.CreateProduct(dto);

            await _repository.SaveAsync();

            return Ok(dto);
        }
    }
}
