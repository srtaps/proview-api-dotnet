using ProductReviewAPI.Dtos.Review;
using ProductReviewAPI.Entities;

namespace ProductReviewAPI.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewsAsync();
        Task<Review?> GetReviewAsync(int id);
        Task<Review> AddReviewAsync(Review review);
        Task<Review?> UpdateReviewAsync(int id, Review review);
        Task<Review?> DeleteAsync(int id);
    }
}
