using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductReviewAPI.Dtos.Product
{
    public class AddProductDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Product name must be at least 5 characters")]
        [MaxLength(250, ErrorMessage = "Product name cannot be longer than 250 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Brand name cannot be longer than 100 characters")]
        public string Brand { get; set; } = string.Empty;
        [Required]
        [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(1,1000000000)]
        public decimal Price { get; set; }
    }
}
