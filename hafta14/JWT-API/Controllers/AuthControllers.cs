using JWT_API.DTOs;
using JWT_API.HelperFunctions;
using JWT_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWT_API.Controllers
{
    // Route configuration for the AuthController
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthControllers(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AuthControllers> logger, TokenService tokenService) : ControllerBase
    {
        private readonly UserManager<User> _userManager = userManager; // Handles user management tasks
        private readonly SignInManager<User> _signInManager = signInManager; // Handles user sign-in tasks
        private readonly TokenService _tokenService = tokenService; // Service to generate tokens
        private readonly ILogger<AuthControllers> _logger = logger; // Logger for logging information and errors

        // Register a new user
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Register registerDto)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError("Validation error: {Error}", error.ErrorMessage);
                    }
                }
                return BadRequest(ModelState); // Return bad request with model state errors
            }

            // Create a new user instance
            var newUser = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };

            // Try to create the user
            var creationResult = await _userManager.CreateAsync(newUser, registerDto.Password);
            if (creationResult.Succeeded)
            {
                _logger.LogInformation("User created successfully.");
                return Ok(new { Message = "User registered successfully", User = newUser });
            }

            // Log errors if user creation failed
            foreach (var error in creationResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                _logger.LogError("User creation failed: {Error}", error.Description);
            }

            return BadRequest(ModelState); // Return bad request with error details
        }

        // User login method
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login loginDto)
        {
            // Find user by email
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                _logger.LogError("Login failed: User not found.");
                return BadRequest(new { Message = "Invalid login attempt." });
            }

            // Check password sign-in
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (signInResult.Succeeded)
            {
                _logger.LogInformation("User logged in successfully.");
                return Ok(new { Token = _tokenService.CreateToken(user) });
            }
            else
            {
                _logger.LogError("Login failed: Incorrect password.");
                return BadRequest(new { Message = "Invalid login attempt." });
            }
        }
    }
}

