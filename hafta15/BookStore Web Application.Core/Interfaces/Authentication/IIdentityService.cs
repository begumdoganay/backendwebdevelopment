using BookStore_Web_Application.Core.Dtos.Authentication;

namespace BookStore_Web_Application.Core.Interfaces.Authentication
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string refreshToken);
        Task RevokeTokenAsync(string refreshToken);
    }
}