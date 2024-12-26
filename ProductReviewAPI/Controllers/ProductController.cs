using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductReviewAPI.Data;
using ProductReviewAPI.Dtos.Product;
using ProductReviewAPI.Helpers;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Mappers;

namespace ProductReviewAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IProductRepository _productRepo;
        public ProductController(ApplicationDbContext dbContext, IProductRepository productRepo)
        {
            _productRepo = productRepo;
            _dbContext = dbContext;
        }

        [Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] QueryObject query)
        {
            var products = await _productRepo.GetProductsAsync(query);
            var productDto = products.Select(p => p.MapToProductDto()).ToList();

            return Ok(productDto);
        }

        [Authorize]
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _productRepo.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.MapToProductDto());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto addProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = addProductDto.MapToProduct();

            await _productRepo.AddProductAsync(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product.MapToProductDto());
        }

        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productRepo.UpdateProductAsync(id, updateProductDto.MapToUpdateProduct());

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.MapToProductDto());
        }

        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = await _productRepo.DeleteProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
