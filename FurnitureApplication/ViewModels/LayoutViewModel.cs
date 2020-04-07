using App.ViewModels.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace App.ViewModels
{
    public class LayoutViewModel
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public string User { get; set; }

        public SignInManager<AppUser> SignInManager { get; set; }

        public UserManager<AppUser> UserManager { get; set; }

        //public int MyProperty { get; set; }

        public LayoutViewModel(SignInManager<AppUser> signIn, UserManager<AppUser> user)
        {
            //_httpContextAccessor = httpContextAccessor;
            UserManager = user;
            SignInManager = signIn;
            //User = System.Web.HttpContext.Current.User.
        }

    }
}
