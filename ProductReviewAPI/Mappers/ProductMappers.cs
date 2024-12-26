using System.Runtime.CompilerServices;
using ProductReviewAPI.Dtos.Product;
using ProductReviewAPI.Entities;

namespace ProductReviewAPI.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto MapToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Description = product.Description,
                Price = product.Price,
                Reviews = product.Reviews.Select(r => r.MapToReviewDto()).ToList()
            };
        }

        public static Product MapToProduct(this AddProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Description = productDto.Description,
                Price = productDto.Price
            };
        }

        public static Product MapToUpdateProduct(this UpdateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Description = productDto.Description,
                Price = productDto.Price
            };
        }
    }
}
