using System.ComponentModel.DataAnnotations;

namespace ProductReviewAPI.Dtos.Review
{
    public class UpdateReviewDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters")]
        [MaxLength(200, ErrorMessage = "Title cannot be over 200 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Text must be at least 5 characters")]
        [MaxLength(1000, ErrorMessage = "Text cannot be over 1000 characters")]
        public string Text { get; set; } = string.Empty;
    }
}
