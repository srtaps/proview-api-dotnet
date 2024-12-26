using ProductReviewAPI.Dtos.Product;
using ProductReviewAPI.Dtos.Review;
using ProductReviewAPI.Entities;

namespace ProductReviewAPI.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto MapToReviewDto(this Review review)
        {
            return new ReviewDto
            {
                Id = review.Id,
                Title = review.Title,
                Text = review.Text,
                CreatedOn = review.CreatedOn,
                CreatedBy = review.User.UserName,
                ProductId = review.ProductId
            };
        }

        public static Review MapToReview(this AddReviewDto addReviewDto, int stockId)
        {
            return new Review
            {
                Title = addReviewDto.Title,
                Text = addReviewDto.Text,
                ProductId = stockId
            };
        }

        public static Review MapToUpdateReview(this UpdateReviewDto updateReviewDto)
        {
            return new Review
            {
                Title = updateReviewDto.Title,
                Text = updateReviewDto.Text
            };
        }
    }
}
