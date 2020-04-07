using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Products
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Barcode { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }
    }
}
