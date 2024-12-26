using ProductReviewAPI.Dtos.Product;
using ProductReviewAPI.Entities;
using ProductReviewAPI.Helpers;

namespace ProductReviewAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync(QueryObject query);
        Task<Product?> GetProductAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, Product product);
        Task<Product?> DeleteProductAsync(int id);
        Task<bool> ProductExists(int id);
    }
}
