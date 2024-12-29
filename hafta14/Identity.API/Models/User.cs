using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.API.Models
{
    // Represents a user in the identity system.
    // Inherits from IdentityUser to provide user management functionalities.

    public class User : IdentityUser<Guid>
    {
        // Gets or sets the user's full name.
        // This property can be used for display purposes.

        public string FullName { get; set; } = string.Empty;
        // Gets or sets the date when the user registered.

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        /// Gets or sets the last login date and time for the user.

        public DateTime? LastLoginAt { get; set; }

        // Updates the user's full name.

        // <param name="fullName">The new full name for the user.</param>
        public void UpdateFullName(string fullName)
        {
            FullName = fullName;
        }

        // Updates the last login date and time to the current date and time.

        public void UpdateLastLogin()
        {
            LastLoginAt = DateTime.UtcNow;
        }
    }
}



