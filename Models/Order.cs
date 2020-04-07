using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }

        public string InvoiceNumber { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public IList<ProductOrder> ProductOrders { get; set; }
    }
}
