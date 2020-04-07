using Service.Accounts;
using Service.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }

        public string InvoiceNumber { get; set; }

        public IList<ProductOrderDto> Products { get; set; } = new List<ProductOrderDto>();
    }
}
