using System.ComponentModel.DataAnnotations;

namespace ProductReviewAPI.Dtos.User
{
    public class LoginUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
