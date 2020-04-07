using AutoMapper;
using Data.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product = await _productRepository.Create(product);
            dto.Id = product.Id;
            return dto;
        }

        public async Task<ProductDto> Delete(ProductDto dto)
        {
            var product = await _productRepository.GetProduct(dto.Id);
            if (product != null)
            {
                product = await _productRepository.Delete(product);
            }

            return dto;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products = new List<ProductDto>();
            foreach (var product in await _productRepository.GetAll())
            {
                var productDto = _mapper.Map<ProductDto>(product);
                products.Add(productDto);
            }

            return products;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            var dto = _mapper.Map<ProductDto>(product);
            return dto;
        }

        public async Task<ProductDto> Update(ProductDto dto)
        {
            var product = await _productRepository.GetProduct(dto.Id);
            if (product != null)
            {
                product.Name = dto.Name;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.Barcode = dto.Barcode;
                product.CategoryId = dto.CategoryId;
                product = await _productRepository.Update(product);
            }

            return dto;
        }

        public async Task<bool> BarcodeExists(string barcode)
        {
            return await _productRepository.BarcodeExists(barcode);
        }
    }
}
