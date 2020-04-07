using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);

        Task<List<Product>> GetAll();

        Task<Product> Create(Product product);

        Task<Product> Update(Product product);

        Task<Product> Delete(Product product);

        Task<bool> BarcodeExists(string barcode);
    }
}
