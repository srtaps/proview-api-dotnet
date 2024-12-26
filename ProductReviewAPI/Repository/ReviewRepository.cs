using Microsoft.EntityFrameworkCore;
using ProductReviewAPI.Data;
using ProductReviewAPI.Dtos.Review;
using ProductReviewAPI.Entities;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Mappers;

namespace ProductReviewAPI.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReviewRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Review>> GetReviewsAsync()
        {
            return await _dbContext.Reviews
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<Review?> GetReviewAsync(int id)
        {
            return await _dbContext.Reviews
                .Include(u => u.User)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            await _dbContext.Reviews.AddAsync(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review?> UpdateReviewAsync(int id, Review review)
        {
            var existingReview = await _dbContext.Reviews.Include(u => u.User).FirstOrDefaultAsync(r => r.Id == id);

            if (existingReview == null)
            {
                return null;
            }

            existingReview.Title = review.Title;
            existingReview.Text = review.Text;

            await _dbContext.SaveChangesAsync();

            return existingReview;
        }

        public async Task<Review?> DeleteAsync(int id)
        {
            var review = await _dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id);

            if (review == null)
            {
                return null;
            }

            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync();

            return review;
        }
    }
}
