using App.ViewModels.Accounts;
using App.ViewModels.Orders;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Accounts;
using Service.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly IOrderService _orderService;

        private readonly IMapper _mapper;


        public OrderController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IOrderService orderService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserAsync(User).Result.Id;
            var dtoList = await _orderService.GetUserOrders(userId);
            var modelList = _mapper.Map<List<OrderViewModel>>(dtoList);
            return View(modelList);
        }
    }
}
