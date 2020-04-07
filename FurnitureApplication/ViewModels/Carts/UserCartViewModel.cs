using Models;
using Service.Accounts;
using Service.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels.Carts
{
    public class UserCartViewModel
    {
        public string UserId { get; set; }

        public IList<CartItemWithDetailsViewModel> CartItems { get; set; } = new List<CartItemWithDetailsViewModel>();
    }
}
