using System.ComponentModel.DataAnnotations;

namespace ProductReviewAPI.Dtos.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public int ProductId { get; set; } // Foreign Key to the Product
    }
}
