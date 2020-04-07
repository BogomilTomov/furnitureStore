using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetUserOrders(string userId);
    }
}
