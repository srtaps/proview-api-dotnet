using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductReviewAPI.Entities;

namespace ProductReviewAPI.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            var review1 = new Review
            {
                Id = 1,
                Title = "Great Smartphone",
                Text = "Excellent performance",
                CreatedOn = DateTime.Now,
                ProductId = 1,
                UserId = "a1-b2"
            };

            var review2 = new Review
            {
                Id = 2,
                Title = "Doesn't disappoint",
                Text = "This brand always delivers",
                CreatedOn = DateTime.Now,
                ProductId = 1,
                UserId = "a1-b2"
            };

            var review3 = new Review
            {
                Id = 3,
                Title = "Runs Crysis",
                Text = "60fps",
                CreatedOn = DateTime.Now,
                ProductId = 3,
                UserId = "a1-b2"
            };

            var review4 = new Review
            {
                Id = 4,
                Title = "Very good sound",
                Text = "I don't go outside with them",
                CreatedOn = DateTime.Now,
                ProductId = 4,
                UserId = "a1-b2"
            };

            builder.HasData(review1, review2, review3, review4);
        }
    }
}
