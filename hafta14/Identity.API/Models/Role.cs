using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.API.Models
{

    // Represents a role in the identity system.
    // Inherits from IdentityRole to provide role management functionalities.

    public class Role : IdentityRole<Guid>
    {

        // Gets or sets the description of the role.
        // This property provides additional context about the role's purpose.

        public string Description { get; set; } = string.Empty;

        // Gets or sets the date and time when the role was created.

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Gets or sets the date and time when the role was last updated.

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Updates the role's properties with the given values.

        // <param name="description">The new description for the role.</param>
        public void UpdateRole(string description)
        {
            Description = description;
            UpdatedAt = DateTime.UtcNow; // Update the timestamp on modification
        }
    }
}