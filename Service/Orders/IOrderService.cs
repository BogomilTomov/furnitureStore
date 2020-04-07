using Service.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Orders
{
    public interface IOrderService
    {
        public Task<List<OrderDto>> GetUserOrders(string userId);
    }
}
