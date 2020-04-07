using Service.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Carts
{
    public interface ICartService
    {
        public Task<CartItemDto> CreateCartItem(CartItemDto dto);

        public Task<List<CartItemWithDetailsDto>> GetUserCartItems(string userId);

        public Task<CartItemWithDetailsDto> DeleteCartItem(CartItemWithDetailsDto dto);

        public Task<CartItemWithDetailsDto> UpdateCartItem(CartItemWithDetailsDto dto);

        public Task<CartItemDto> AddToCart(CartItemDto dto, string userId);

        public Task<List<CartItemWithDetailsDto>> PlaceOrder(List<CartItemWithDetailsDto> dtoList, string userId);
    }
}
