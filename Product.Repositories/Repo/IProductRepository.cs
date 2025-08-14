using Product.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repositories.Repo
{
    public interface IProductRepository
    {
        //bütün ürünleri getirir.
        Task<List<ProductModel>> GetAllProductAsync();
        // idye gören ürünümüzü getirir.
        Task<ProductModel?> GetProductGetByIdAsync(int id);
        //ekleme
        Task<ProductModel> AddProductAsync(ProductModel product);
        //güncelleme 
        Task<ProductModel> UpdateProductAsync(ProductModel product);
        //slilme
        Task DeleteProductAsync(int id);
    }
}
