using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Carts
{
    public class CartItemDto
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
