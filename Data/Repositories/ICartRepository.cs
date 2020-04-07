using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICartRepository
    {
        public Task<CartItem> CreateCartItem(CartItem cartItem);

        public Task<CartItem> UpdateCartItem(CartItem cartItem);

        public Task<List<CartItem>> GetUserCartItems(string userId);

        public Task<CartItem> GetCartItem(int id);

        public Task<CartItem> GetCartItemAlreadyInCart(int productId, string userId);

        public Task<CartItem> DeleteCartItem(CartItem cartItem);

        public Task<Order> CreateNewOrder(Order order);

        public Task<ProductOrder> CreateProductOrder(ProductOrder productOrder);
    }
}
