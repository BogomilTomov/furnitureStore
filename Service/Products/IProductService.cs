using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Products
{
    public interface IProductService
    {
        Task<ProductDto> GetProduct(int id);

        Task<List<ProductDto>> GetAll();

        Task<ProductDto> Create(ProductDto product);

        Task<ProductDto> Update(ProductDto product);

        Task<ProductDto> Delete(ProductDto product);

        Task<bool> BarcodeExists(string barcode);
    }
}
