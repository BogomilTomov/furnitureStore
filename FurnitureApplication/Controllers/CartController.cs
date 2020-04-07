using App.ViewModels.Carts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly ICartService _cartService;

        private readonly IMapper _mapper;

        public CartController(UserManager<AppUser> userManager,
            ICartService cartService, 
            IMapper mapper)
        {
            _userManager = userManager;
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartViewModel model)
        {
            if (model.Quantity > 0)
            {
                var userId = _userManager.GetUserAsync(User).Result.Id;
                var dto = _mapper.Map<CartItemDto>(model);
                dto.UserId = userId;
                
                await _cartService.AddToCart(dto, userId);
                return RedirectToAction(nameof(Index));
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId  = _userManager.GetUserAsync(User).Result.Id;
            var model = new UserCartViewModel()
            {
                UserId = userId
            };

            model.CartItems = _mapper.Map<List<CartItemWithDetailsViewModel>>(await _cartService.GetUserCartItems(userId));
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(UserCartViewModel model)
        {
            var userId = _userManager.GetUserAsync(User).Result.Id;
            var cartItems = await _cartService.GetUserCartItems(userId);
            await _cartService.PlaceOrder(cartItems, userId);
            return RedirectToAction(nameof(Index), "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(RemoveFromCartViewModel model)
        {
            var dto = new CartItemWithDetailsDto()
            {
                Id = model.CartItemId
            };

            await _cartService.DeleteCartItem(dto);
            return RedirectToAction(nameof(Index), "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCartItem model)
        {
            var dto = new CartItemWithDetailsDto()
            {
                Id = model.CartItemId,
                Quantity = model.Quantity
            };

            await _cartService.UpdateCartItem(dto);
            return RedirectToAction(nameof(Index), "Cart");
        }
    }
}
