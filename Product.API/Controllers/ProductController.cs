using Microsoft.AspNetCore.Mvc;
using Product.Services.Dtos;
using Product.Services.ProductServices;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = $"Ürün (Id: {id}) bulunamadı." });
            }
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductDto dto)
        {
            try
            {
                var addedProduct = await _productService.AddProductAsync(dto);
                return Ok(new { message = "Ürün başarıyla eklendi.", product = addedProduct });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/products
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDto productDto)
        {
            try
            {
                await _productService.UpdateProductAsync(productDto);
                return Ok(new { message = "Ürün başarıyla güncellendi." });
            }
            catch (Exception ex)
            {
                // Servis katmanından gelen tüm hataları BadRequest olarak döndürdüm.
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = $"Silinecek ürün (Id: {id}) bulunamadı." });
            }

            await _productService.DeleteProductAsync(id);
            return Ok(new { message = "Ürün başarıyla silindi." });
        }
    }
}
