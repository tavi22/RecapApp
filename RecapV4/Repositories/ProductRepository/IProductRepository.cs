using RecapV4.Models.DTOs;
using RecapV4.Models.Entities;

namespace RecapV4.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetById(int id);
        Task<List<Product>> GetByBarcode(string barcode);
        Task<List<Product>> GetByCategory(string category); 
        Task<List<Product>> GetBySubcategory(string subcategory);
        Task<List<Product>> GetBySize(string size);
        Task<List<Product>> GetByColor(string color);
        void UpdateProduct(int id, ProductDTO dto);

        void CreateProduct(ProductDTO dto);

        void DeleteProduct(int id);
    }
}
