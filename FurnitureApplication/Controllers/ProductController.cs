using App.ViewModels.Products;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Categories;
using Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dtoList = await _productService.GetAll();
            var model = _mapper.Map<List<ProductDetailsViewModel>>(dtoList);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _productService.GetProduct(id);
            var model = _mapper.Map<ProductDetailsViewModel>(dto);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categoriesOptions = new List<SelectListItem>();
            var categories = await _categoryService.ShowAll();
            foreach (var category in categories)
            {
                categoriesOptions.Add(new SelectListItem { Value = (category.Id).ToString(), Text = category.Name });
            }

            ViewBag.CategoriesOptions = categoriesOptions;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ProductDto>(model);
                dto = await _productService.Create(dto);
                return RedirectToAction(nameof(Details), new { id = dto.Id });
            }

            return await Create();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _productService.GetProduct(id);
            var model = _mapper.Map<EditProductViewModel>(dto);

            var categoriesOptions = new List<SelectListItem>();
            var categories = await _categoryService.ShowAll();
            foreach (var category in categories)
            {
                categoriesOptions.Add(new SelectListItem { Value = (category.Id).ToString(), Text = category.Name });
            }

            ViewBag.CategoriesOptions = categoriesOptions;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ProductDto>(model);
                dto = await _productService.Update(dto);
                return RedirectToAction(nameof(Details), new { id = dto.Id });
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = new ProductDto();
            dto.Id = id;
            dto = await _productService.Delete(dto);
            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> UniqueBarcode(string barcode)
        {
            if (_productService.BarcodeExists(barcode).Result == true)
            {
                return Json($"Product with this barcode already exists");
            }

            return Json(true);
        }
    }
}
