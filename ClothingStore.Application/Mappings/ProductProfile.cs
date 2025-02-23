using AutoMapper;
using ClothingStore.Application.DTOs;
using ClothingStore.Domain.Entities;

namespace ClothingStore.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        { 
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
