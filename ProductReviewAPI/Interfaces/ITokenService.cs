using ProductReviewAPI.Entities;

namespace ProductReviewAPI.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
