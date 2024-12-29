using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using JWT_API.Datas;
using JWT_API.Models;

namespace JWT_API.Controllers
{
    // Define the route for this controller
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Ensure that only authorized users can access this controller
    public class UsersController : ControllerBase
    {
        private readonly Context _context; // Database context
        private readonly ILogger<UsersController> _logger; // Logger for logging information and errors

        public UsersController(Context context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET api/users - Retrieve all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                // Fetch the requesting user to log their username
                var currentUserName = User.Identity?.Name; // Get the username first
                User? currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == currentUserName);
                _logger.LogInformation("User {UserName} is requesting the list of all users", currentUser?.UserName ?? "Unknown");

                // Retrieve all users from the database
                var users = await _context.Users.ToListAsync();

                if (users == null || users.Count == 0)
                {
                    _logger.LogWarning("No users found in the database.");
                    return NotFound(new { Message = "No users found." });
                }

                // Log the successful retrieval of users
                _logger.LogInformation("Successfully retrieved {Count} users", users.Count);
                return Ok(users); // Return the list of users
            }
            catch (DbUpdateException dbEx)
            {
                // Log database update exceptions
                _logger.LogError("Database update error: {Message}", dbEx.Message);
                return StatusCode(500, "Internal server error while accessing the database.");
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                _logger.LogError("An unexpected error occurred: {Message}", ex.Message);
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}

