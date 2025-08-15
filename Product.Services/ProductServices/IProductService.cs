using Product.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.ProductServices
{
    public interface IProductService
    {
        //tüm ürünlerimizi listenelenicek.
        Task<List<ProductDto>> GetAllProductsAsync();
        //Ürün ekleme
        Task<ProductDto> AddProductAsync(CreateProductDto product);
        //Ürün güncelleme
        Task UpdateProductAsync(ProductDto productDto);
        //ürün silme
        Task DeleteProductAsync(int id);
        Task<ProductDto?> GetProductByIdAsync(int id);


    }
}
