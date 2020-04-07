using App.ViewModels.Accounts;
using App.ViewModels.Products;
using System;
using System.Collections.Generic;

namespace App.ViewModels.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }

        public string InvoiceNumber { get; set; }

        public IList<ProductOrderViewModel> Products { get; set; } = new List<ProductOrderViewModel>();
    }
}