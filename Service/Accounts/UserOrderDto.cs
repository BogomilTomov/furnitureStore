using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Accounts
{
    public class UserOrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string InvoiceNumber { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
