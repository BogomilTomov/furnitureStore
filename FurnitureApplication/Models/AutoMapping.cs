using App.ViewModels.Carts;
using App.ViewModels.Categories;
using App.ViewModels.Orders;
using App.ViewModels.Products;
using AutoMapper;
using Service.Accounts;
using Service.Carts;
using Service.Categories;
using Service.Orders;
using Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<List<CategoryDto>, List<CategoryViewModel>>();
            CreateMap<CategoryViewModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<CategoryDetailsViewModel, CategoryDetailsDto>();
            CreateMap<CategoryDetailsDto, CategoryDetailsViewModel>();
            CreateMap<ProductDto, ProductDetailsViewModel>();
            CreateMap<CreateProductViewModel, ProductDto>();
            CreateMap<ProductDto, EditProductViewModel>();
            CreateMap<EditProductViewModel, ProductDto>();
            CreateMap<AddToCartViewModel, CartItemDto>();
            CreateMap<CartItemWithDetailsDto, CartItemWithDetailsViewModel>();
            CreateMap<OrderDto, OrderViewModel>();
            CreateMap<ProductOrderDto, ProductOrderViewModel>();
        }
    }
}
