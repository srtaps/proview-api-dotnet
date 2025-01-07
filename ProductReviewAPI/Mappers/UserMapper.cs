using ProductReviewAPI.Dtos.Review;
using ProductReviewAPI.Dtos.User;
using ProductReviewAPI.Entities;

namespace ProductReviewAPI.Mappers
{
    public static class UserMapper
    {
        public static UserDto MapToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }
    }
}
