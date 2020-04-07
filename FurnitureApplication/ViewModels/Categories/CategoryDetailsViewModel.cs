using App.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels.Categories
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductDetailsViewModel> Products { get; set; } = new List<ProductDetailsViewModel>();
    }
}
