using Microsoft.EntityFrameworkCore;
using RecapV4.Models.Data;
using RecapV4.Models.DTOs;
using RecapV4.Models.Entities;

namespace RecapV4.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(RecapContext context) : base(context) { }

        public void CreateProduct(ProductDTO dto)
        {
            Product newProduct = new Product();

            newProduct.Name = dto.Name;
            newProduct.Barcode = dto.Barcode;
            newProduct.Category = dto.Category;
            newProduct.Subcategory = dto.Subcategory;
            newProduct.Size = dto.Size;
            newProduct.Color = dto.Color;

            Create(newProduct);
        }

        public async void DeleteProduct(int id)
        {
            Product product = new Product();
            product = await GetByIdAsync(id);

            Delete(product);
        }

        public async Task<List<Product>> GetByBarcode(string barcode)
        {
            return await _context.Products.Where(p => p.Barcode.Equals(barcode)).ToListAsync();
        }

        public async Task<List<Product>> GetByCategory(string category)
        {
            return await _context.Products.Where(p => p.Category.Equals(category)).ToListAsync();

        }

        public async Task<List<Product>> GetByColor(string color)
        {
            return await _context.Products.Where(p => p.Color.Equals(color)).ToListAsync();

        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<List<Product>> GetBySize(string size)
        {
            return await _context.Products.Where(p => p.Size.Equals(size)).ToListAsync();

        }

        public async Task<List<Product>> GetBySubcategory(string subcategory)
        {
            return await _context.Products.Where(p => p.Subcategory.Equals(subcategory)).ToListAsync();

        }

        public void UpdateProduct(int id, ProductDTO dto)
        {
            Product newProduct = new Product();

            newProduct.Id = id;
            newProduct.Name = dto.Name;
            newProduct.Barcode = dto.Barcode;
            newProduct.Category = dto.Category;
            newProduct.Subcategory = dto.Subcategory;
            newProduct.Size = dto.Size;
            newProduct.Color = dto.Color;
            
            Update(newProduct);
        }
    }
}
