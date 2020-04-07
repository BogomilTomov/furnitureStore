using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CartItem> CreateCartItem(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<CartItem> UpdateCartItem(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<CartItem> DeleteCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<List<CartItem>> GetUserCartItems(string userId)
        {
            return await _context.CartItems.Include(ci => ci.Product).Where(ci => ci.UserId == userId).ToListAsync();
        }

        public async Task<CartItem> GetCartItem(int id)
        {
            return await _context.CartItems.SingleOrDefaultAsync(ci => ci.Id == id);
        }

        public async Task<CartItem> GetCartItemAlreadyInCart(int productId, string userId)
        {
            return await _context.CartItems.SingleOrDefaultAsync(ci => ci.ProductId == productId && ci.UserId == userId);
        }

        public async Task<Order> CreateNewOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<ProductOrder> CreateProductOrder(ProductOrder productOrder)
        {
            await _context.ProductOrders.AddAsync(productOrder);
            await _context.SaveChangesAsync();
            return productOrder;
        }
    }
}
