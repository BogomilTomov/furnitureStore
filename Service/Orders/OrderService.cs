using AutoMapper;
using Data.Repositories;
using Service.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> GetUserOrders(string userId)
        {
            var userOrders = await _orderRepository.GetUserOrders(userId);
            var dtoList = new List<OrderDto>();
            foreach (var order in userOrders)
            {
                var dto = _mapper.Map<OrderDto>(order);
                foreach (var product in order.ProductOrders)
                {
                    var productItem = new ProductOrderDto();
                    productItem.ProductName = product.Product.Name;
                    productItem.Price = product.Product.Price;
                    productItem.Quantity = product.Quantity;
                    dto.Products.Add(productItem);
                    //var productItem = _mapper.Map<ProductOrderDto>(product);
                }

                dtoList.Add(dto);
            }

            //var dtoList = _mapper.Map<List<OrderDto>>(userOrders);
            return dtoList;
        }
    }
}
