using BookStore_Web_Application.Core.Entities;

namespace BookStore_Web_Application.Core.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, IList<string> roles);
        string GenerateRefreshToken();
    }
}
