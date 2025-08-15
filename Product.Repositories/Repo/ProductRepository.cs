using Microsoft.EntityFrameworkCore;
using Product.Repositories.Context;
using Product.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repositories.Repo
{
    public class ProductRepository : IProductRepository
    {
        //Dependy Injection
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context= context; 
        }
        public async Task<ProductModel> AddProductAsync(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=> x.Id == id);
            if (product != null) 
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }

        public async Task<ProductModel?> GetProductByIdAsync(int id)
        {
            var product =await _context.Products.FindAsync(id);
            return product;

        }

        public async Task<ProductModel> UpdateProductAsync(ProductModel product)
        {
           _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
