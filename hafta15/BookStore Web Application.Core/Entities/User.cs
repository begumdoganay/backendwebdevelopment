using BookStore_Web_Application.Core.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Services.UserAccountMapping;

namespace BookStore_Web_Application.Core.Entities
{
    public class User : IdentityUser<int>
    {
        private bool emailConfirmed;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public override string? PasswordHash { get; set; } = string.Empty;
        public string? PasswordSalt { get; set; }

        public bool GetEmailConfirmed()
        {
            return emailConfirmed;
        }

        public void SetEmailConfirmed(bool value)
        {
            emailConfirmed = value;
        }

        public DateTime? LastLoginDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
        public IList<UserRole>? UserRoles { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }

}
