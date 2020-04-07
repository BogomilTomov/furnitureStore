using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategory(int id);

        Task<Category> GetCategoryWithProducts(int id);

        Task<List<Category>> GetAll();

        Task<Category> Create(Category category);

        Task<Category> Update(Category category);

        Task<Category> Delete(Category category);
}
}
