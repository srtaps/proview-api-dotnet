using System.Data;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductReviewAPI.Dtos.User;
using ProductReviewAPI.Entities;
using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Mappers;

namespace ProductReviewAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        public UserController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginUserDto.Username.ToLower());
            if (user == null)
            {
                return Unauthorized("Username not found");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Username or password is invalid");
            }

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = await _tokenService.CreateToken(user)
                }
            );
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUserByEmail = await _userManager.FindByEmailAsync(registerUserDto.Email);
                if (existingUserByEmail != null)
                {
                    return BadRequest("Email is already registered");
                }

                var user = new User
                {
                    UserName = registerUserDto.Username,
                    Email = registerUserDto.Email,
                };

                var createdUser = await _userManager.CreateAsync(user, registerUserDto.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = await _tokenService.CreateToken(user)
                            }    
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            var usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                var role = await _userManager.GetRolesAsync(user);
                usersDto.Add(new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = role.FirstOrDefault()
                });
            }

            return Ok(usersDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] EditUserDto editUserDto)
        {
            if (string.IsNullOrEmpty(editUserDto.UserName) 
                || string.IsNullOrEmpty(editUserDto.Email) 
                || string.IsNullOrEmpty(editUserDto.Role))
            {
                return BadRequest("All fields are required");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var currentRole = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRole);

            var result = await _userManager.AddToRoleAsync(user, editUserDto.Role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            user.UserName = editUserDto.UserName;
            user.Email = editUserDto.Email;

            result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = "User updated successfully" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} not found.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = $"User {id} was deleted successfully." });
        }
    }
}
