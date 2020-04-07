using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetCategory(int id);

        Task<CategoryDetailsDto> GetCategoryWithProducts(int id);

        Task<List<CategoryDto>> ShowAll();

        Task<CategoryDto> Create(CategoryDto dto);

        Task<CategoryDto> Update(CategoryDto category);

        Task<CategoryDto> Delete(CategoryDto category);
    }
}
