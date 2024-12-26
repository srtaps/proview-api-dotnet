using ProductReviewAPI.Entities;

namespace ProductReviewAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
