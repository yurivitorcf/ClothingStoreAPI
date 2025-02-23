using AutoMapper;
using ClothingStore.Application.DTOs;
using ClothingStore.Application.Interfaces;
using ClothingStore.Domain.Entities;
using ClothingStore.Domain.Repositories;

namespace ClothingStore.Application.Services

{
    
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddProductAsync(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            if (product.Price < 0)
                throw new ArgumentException("Price cannot be negative");
            
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductResponseDto?>(product);
        }

        public async Task UpdateProductAsync(int id, UpdateProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null) 
                throw new KeyNotFoundException("Product not found");

            _mapper.Map(productDto, existingProduct);
            await _productRepository.UpdateAsync(existingProduct);
        }
    }
}
