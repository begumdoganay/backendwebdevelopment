using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Identity.API.Datas;
using Identity.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly Context _context;
            private readonly ILogger<UsersController> _logger;

            public UsersController(Context context, ILogger<UsersController> logger)
            {
                _context = context;
                _logger = logger;
            }

            // Retrieves all users from the database.
            // <returns>List of users or NotFound response</returns>
            [HttpGet]

            public async Task<ActionResult<IEnumerable<User>>> GetUsers()
            {
                try
                {
                    var users = await _context.Users.ToListAsync();

                    if (users == null || users.Count == 0)
                    {
                        _logger.LogInformation("No users found in the database.");
                        return NotFound("No users found.");
                    }

                    _logger.LogInformation("Retrieved {Count} users from the database.", users.Count);
                    return Ok(users);
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "Database update error occurred while retrieving users.");
                    return StatusCode(500, "Internal server error while retrieving users.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An unexpected error occurred while retrieving users.");
                    return StatusCode(500, "An unexpected error occurred.");
                }
            }
        }
}
