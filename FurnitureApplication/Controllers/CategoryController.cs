using App.ViewModels.Categories;
using App.ViewModels.Products;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Categories;
using Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryRepository, IMapper mapper)
        {
            _categoryService = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dtoList = await _categoryService.ShowAll();
            var model = new List<CategoryViewModel>();
            foreach (var dto in dtoList)
            {
                model.Add(_mapper.Map<CategoryViewModel>(dto));
            }
            //var model = _mapper.Map<List<CategoryViewModel>>(dtoList);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var dto = await _categoryService.GetCategoryWithProducts(id);
            var model = _mapper.Map<CategoryDetailsViewModel>(dto);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = new CategoryDto();
                dto.Name = model.Name;
                dto = await _categoryService.Create(dto);
                return RedirectToAction(nameof(Details), new { id = dto.Id });
            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _categoryService.GetCategory(id);
            var model = _mapper.Map<CategoryViewModel>(dto);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<CategoryDto>(model);
                dto = await _categoryService.Update(dto);
                return RedirectToAction(nameof(Details), new { id = dto.Id });
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = new CategoryDto();
            dto.Id = id;
            dto = await _categoryService.Delete(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
