using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductReviewAPI.Dtos.Review;
using ProductReviewAPI.Entities;
using ProductReviewAPI.Extensions;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Mappers;

namespace ProductReviewAPI.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IProductRepository _productRepo;
        private readonly UserManager<User> _userManager;
        public ReviewController(IReviewRepository reviewRepo, IProductRepository productRepo, UserManager<User> userManager)
        {
            _reviewRepo = reviewRepo;
            _productRepo = productRepo;
            _userManager = userManager;
        }

        [Authorize]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _reviewRepo.GetReviewsAsync();
            var reviewDto = reviews.Select(p => p.MapToReviewDto());

            return Ok(reviewDto);
        }

        [Authorize]
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReview([FromRoute] int id)
        {
            var review = await _reviewRepo.GetReviewAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review.MapToReviewDto());
        }

        [Authorize]
        [HttpPost("{productId:int}")]
        public async Task<IActionResult> AddReview([FromRoute] int productId, AddReviewDto addReviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _productRepo.ProductExists(productId))
            {
                return BadRequest("Product does not exist");
            }

            var username = User.GetUsername();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("User is not authenticated.");
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var review = addReviewDto.MapToReview(productId);
            review.UserId = user.Id;

            await _reviewRepo.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review.MapToReviewDto());
        }

        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateReview([FromRoute] int id, [FromBody] UpdateReviewDto updateReviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = await _reviewRepo.UpdateReviewAsync(id, updateReviewDto.MapToUpdateReview());
            if (review == null)
            {
                return NotFound("Review not found");
            }

            return Ok(review.MapToReviewDto());
        }

        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            var review = await _reviewRepo.DeleteAsync(id);

            if(review == null)
            {
                return NotFound("Comment does not exist");
            }

            return Ok(review);
        }
    }
}
