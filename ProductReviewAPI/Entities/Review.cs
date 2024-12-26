using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductReviewAPI.Entities
{
    [Table("Reviews")]
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Text { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public int ProductId { get; set; } // Foreign Key to the Product

        // Navigation Property to the related Product
        public Product Product { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
