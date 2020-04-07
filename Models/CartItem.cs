using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public int Quantity { get; set; }
    }
}
