using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels.Categories
{
    public class CreateCategoryViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name should be at least 4 characters long", MinimumLength = 4)]
        public string Name { get; set; }
    }
}
