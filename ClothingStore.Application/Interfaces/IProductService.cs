using ClothingStore.Application.DTOs;
using ClothingStore.Domain.Entities;

namespace ClothingStore.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto?> GetProductByIdAsync(int id);
        Task AddProductAsync(CreateProductDto productDto);
        Task UpdateProductAsync(int id, UpdateProductDto productDto);
        Task DeleteProductAsync(int id);
    }
}
