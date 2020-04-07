using App.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels.Products
{
    public class CreateProductViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name should be at least 4 characters long", MinimumLength = 4)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0.01, 100000, ErrorMessage = "Price must be bigger than 0")]
        [Required]
        public decimal? Price { get; set; }

        [Required]
        [Remote(action: "UniqueBarcode", controller: "Product")]
        [RegularExpression(@"^[0-9]{8,10}$", ErrorMessage = "Barcode must be between 8 and 10 digits long, no spaces")]
        public string Barcode { get; set; }

        public int CategoryId { get; set; }
    }
}
