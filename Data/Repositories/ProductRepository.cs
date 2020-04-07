using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.Include(p => p.Category).SingleOrDefaultAsync(pr => pr.Id == id);
        }

        public async Task<Product> Update(Product product)
        {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return product;
        }

        public async Task<bool> BarcodeExists(string barcode)
        {
            return await _context.Products.AnyAsync(p => p.Barcode == barcode);
        }
    }
}
