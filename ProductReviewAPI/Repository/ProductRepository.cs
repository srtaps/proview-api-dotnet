using Microsoft.EntityFrameworkCore;
using ProductReviewAPI.Data;
using ProductReviewAPI.Dtos.Product;
using ProductReviewAPI.Entities;
using ProductReviewAPI.Helpers;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Mappers;

namespace ProductReviewAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProductAsync(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return null;
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _dbContext.Products.Include(r => r.Reviews)
                                            .ThenInclude(u => u.User)
                                            .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Product>> GetProductsAsync(QueryObject query)
        {
            var products = _dbContext.Products
                .Include(r => r.Reviews)
                .ThenInclude(u => u.User)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.productName))
            {
                products = products.Where(p => p.Name.Contains(query.productName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    products = query.isDescending ? products.OrderByDescending(p => p.Price) : products.OrderBy(p => p.Price);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public Task<bool> ProductExists(int id)
        {
            return _dbContext.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = product.Name;
            existingProduct.Brand = product.Brand;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;

            await _dbContext.SaveChangesAsync();

            return existingProduct;
        }
    }
}
