using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductReviewAPI.Entities
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Navigation property for related reviews
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
