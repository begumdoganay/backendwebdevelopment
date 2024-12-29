using Microsoft.AspNetCore.Identity;

namespace JWT_API.Models
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
    }
}