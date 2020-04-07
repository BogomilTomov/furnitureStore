using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class AppUser : IdentityUser
    {
        public string CompanyName { get; set; }

        public string Ein { get; set; }

        public string ZipCode { get; set; }

        public IList<Order> Orders { get; set; }

        public IList<CartItem> CartItems { get; set; }
    }
}

