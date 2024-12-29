using Microsoft.AspNetCore.Identity;

namespace JWT_API.Models
{
    public class User : IdentityUser<Guid>
    {
        public DateTime CreatedDate { get; internal set; }
        public object RefreshToken { get; internal set; }
        public object RefreshTokenExpiryTime { get; internal set; }
    }

}
