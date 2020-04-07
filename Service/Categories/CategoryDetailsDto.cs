using Service.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
