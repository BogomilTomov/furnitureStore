using Data.Repositories;
using Models;
using System;
using Service.Products;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Service.Categories
{
    public class  CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryDto dto)
        {
            var newCategory = new Category();
            newCategory.Name = dto.Name;
            newCategory = await _categoryRepository.Create(newCategory);
            dto.Id = newCategory.Id;
            return dto;
        }

        public async Task<CategoryDto> Delete(CategoryDto dto)
        {
            var category = await _categoryRepository.GetCategory(dto.Id);
            if (category != null)
            {
                category = await _categoryRepository.Delete(category);
            }
            
            return dto;
        }

        public async Task<List<CategoryDto>> ShowAll()
        {
            var categories = new List<CategoryDto>();
            foreach (var category in await _categoryRepository.GetAll())
            {
                var newCategory = _mapper.Map<CategoryDto>(category);
                categories.Add(newCategory);
            }

            return categories;
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            var dto = _mapper.Map<CategoryDto>(category);
            return dto;
        }

        public async Task<CategoryDetailsDto> GetCategoryWithProducts(int id)
        {
            var category = await _categoryRepository.GetCategoryWithProducts(id);
            var dto = _mapper.Map<CategoryDetailsDto>(category);
            return dto;
        }

        public async Task<CategoryDto> Update(CategoryDto dto)
        {
            var category = await _categoryRepository.GetCategory(dto.Id);
            if (category != null)
            {
                category.Name = dto.Name;
                category = await _categoryRepository.Update(category);
            }
            
            return dto;
        }
    }
}
