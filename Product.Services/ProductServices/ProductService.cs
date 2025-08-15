using Product.Repositories.Models;
using Product.Repositories.Repo;
using Product.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.ProductServices
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> AddProductAsync(CreateProductDto product)
        {
            try
            {
                var productModel = new ProductModel
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductStock = product.ProductStock
                };
                var addedProduct = await _productRepository.AddProductAsync(productModel);

                // Başarılı olursa DTO'ya dönüştürüp döndürür.
                return new ProductDto
                {
                    Id = addedProduct.Id,
                    ProductName = addedProduct.ProductName,
                    ProductDescription = addedProduct.ProductDescription,
                    ProductPrice = addedProduct.ProductPrice,
                    ProductStock = addedProduct.ProductStock
                };
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ürün eklenirken bir hata oluştu.", ex);
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
            
                return;
            }

            await _productRepository.DeleteProductAsync(id);
        }

        // Tüm ürünleri çeker ve DTO'ya dönüştürür.
        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductStock = p.ProductStock  
            }).ToList();
        }

        // ID'ye göre ürünü çeker ve DTO'ya dönüştürür.
        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription= product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductStock = product.ProductStock
            };
        }


        // Ürün Güncellemede try-catch
       public async Task UpdateProductAsync(ProductDto productDto)
{
    var product = await _productRepository.GetProductByIdAsync(productDto.Id);
    if (product == null)
    {
        throw new Exception($"Güncellenecek ürün (Id: {productDto.Id}) bulunamadı.");
    }

    // DTO'dan gelen verilerle modeli günceller.
    product.ProductName = productDto.ProductName;
    product.ProductDescription = productDto.ProductDescription;
    product.ProductPrice = productDto.ProductPrice;
    product.ProductStock = productDto.ProductStock; 

    await _productRepository.UpdateProductAsync(product);
}

    }
}
