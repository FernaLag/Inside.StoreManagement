using AutoMapper;
using Inside.StoreManagement.Application.Features.Orders.DTOs;
using Inside.StoreManagement.Application.Features.Products.DTOs;
using Inside.StoreManagement.Domain.Entities;

namespace Inside.StoreManagement.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();

            CreateMap<Order, OrderWithProductsDTO>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts));

            CreateMap<OrderProduct, ProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));

            CreateMap<Product, ProductDTO>();
        }
    }
}