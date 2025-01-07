using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductReviewAPI.Entities;

namespace ProductReviewAPI.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var product1 = new Product
            {
                Id = 1,
                Name = "Smartphone",
                Brand = "Brand A1",
                Description = "A high-end smartphone",
                Price = 799.99m
            };

            var product2 = new Product
            {
                Id = 2,
                Name = "Kindle",
                Brand = "Brand B2",
                Description = "An e-book reader",
                Price = 59.99m
            };

            var product3 = new Product
            {
                Id = 3,
                Name = "Laptop",
                Brand = "Brand C3",
                Description = "A gaming laptop",
                Price = 149.99m
            };

            var product4 = new Product
            {
                Id = 4,
                Name = "Wireless Headphones",
                Brand = "Brand D4",
                Description = "Wireless headphones with a long battery life",
                Price = 299.99m
            };

            builder.HasData(product1, product2, product3, product4);
        }
    }
}
