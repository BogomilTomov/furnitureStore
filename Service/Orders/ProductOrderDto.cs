using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Orders
{
    public class ProductOrderDto
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}
