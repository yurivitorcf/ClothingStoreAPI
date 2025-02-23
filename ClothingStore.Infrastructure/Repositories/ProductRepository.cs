using ClothingStore.Domain.Entities;
using ClothingStore.Domain.Repositories;
using ClothingStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);

            if (existingProduct == null)
                throw new InvalidOperationException("Product not found.");

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;  
            existingProduct.Category = product.Category;
            existingProduct.StockQty = product.StockQty;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
        }
    }
}
