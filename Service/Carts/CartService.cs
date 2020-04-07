using AutoMapper;
using Data.Repositories;
using Models;
using Service.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Carts
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartItemDto> AddToCart(CartItemDto dto, string userId)
        {
            var userCartItems = await _cartRepository.GetUserCartItems(userId);
            bool isAlreadyInCart = userCartItems.Any(ci => ci.ProductId == dto.ProductId);
            if (!isAlreadyInCart)
            {
                await CreateCartItem(dto);
            }
            else
            {
                var cartItem = await _cartRepository.GetCartItemAlreadyInCart(dto.ProductId, userId);
                cartItem.Quantity += dto.Quantity;
                await _cartRepository.UpdateCartItem(cartItem);
            }

            return dto;
        }

        public async Task<CartItemWithDetailsDto> UpdateCartItem(CartItemWithDetailsDto dto)
        {
            var cartItem = await _cartRepository.GetCartItem(dto.Id);
            cartItem.Quantity = dto.Quantity;
            await _cartRepository.UpdateCartItem(cartItem);
            return dto;
        }


        public async Task<CartItemDto> CreateCartItem(CartItemDto dto)
        {
            var cartItem = _mapper.Map<CartItem>(dto);
            cartItem = await _cartRepository.CreateCartItem(cartItem);
            return dto;
        }

        public async Task<CartItemWithDetailsDto> DeleteCartItem(CartItemWithDetailsDto dto)
        {
            var cartItem = await _cartRepository.GetCartItem(dto.Id);
            if (cartItem != null)
            {
                cartItem = await _cartRepository.DeleteCartItem(cartItem);
            }

            return dto;
        }

        public async Task<List<CartItemWithDetailsDto>> GetUserCartItems(string userId)
        {
            var cartItems = await _cartRepository.GetUserCartItems(userId);
            var dtoList = _mapper.Map<List<CartItemWithDetailsDto>>(cartItems);
            return dtoList;
        }

        public async Task<List<CartItemWithDetailsDto>> PlaceOrder(List<CartItemWithDetailsDto> dtoList, string userId)
        {
            var date = DateTime.Now;
            decimal totalPrice = dtoList.Sum(dto => dto.Quantity * dto.ProductPrice);
            string invoiceNumber = GenerateInvoiceNumber();
            Order order = new Order()
            {
                Date = date,
                TotalPrice = totalPrice,
                InvoiceNumber = invoiceNumber,
                UserId = userId
            };

            await _cartRepository.CreateNewOrder(order);
            foreach (var dto in dtoList)
            {
                ProductOrder productOrder = new ProductOrder()
                {
                    OrderId = order.Id,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                };

                await _cartRepository.CreateProductOrder(productOrder);
                var cartItem = await _cartRepository.GetCartItem(dto.Id);
                await _cartRepository.DeleteCartItem(cartItem);
            }

            return dtoList;
        }

        private string GenerateInvoiceNumber()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
