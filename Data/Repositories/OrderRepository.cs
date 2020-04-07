using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetUserOrders(string userId)
        {
            return await _context.Orders.Include(o => o.ProductOrders).ThenInclude(po => po.Product).Where(o => o.UserId == userId).ToListAsync();
        }
    }
}
