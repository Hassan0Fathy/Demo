using AutoMapper;
using Demo.Dtos;
using Demo.Dtos.CategoryDto;
using Demo.Dtos.OrderDto;
using Demo.Dtos.OrderItemDto;
using Demo.Dtos.ProductDto;
using Demo.Models;
using Demo.Repos.Implemention;

namespace Demo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<Category, ReadCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, UpdateStockDto>().ReverseMap();
            CreateMap<Product, ReadProductDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
        }
    }
}
