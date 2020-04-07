using AutoMapper;
using Models;
using Service.Carts;
using Service.Categories;
using Service.Orders;
using Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Service
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryDetailsDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>()
                .ForMember(dest =>
                    dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CartItemDto, CartItem>();
            CreateMap<CartItem, CartItemWithDetailsDto>();
            CreateMap<Order, OrderDto>();
/*            CreateMap<ProductOrder, ProductOrderDto>()
                .ForMember(dest =>
                    dest.ProductName,
                    opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest =>
                    dest.Price,
                    opt => opt.MapFrom(src => src.Product.Price));*/
        }
    }
}
