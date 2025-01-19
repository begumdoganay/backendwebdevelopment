
using BookStore_Web_Application.Core.Dtos.Authentication;

namespace BookStore_Web_Application.Core.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<TokenDto> LoginAsync(LoginDto loginDto);
        Task<TokenDto> RefreshTokenAsync(string refreshToken);
        Task LogoutAsync(string refreshToken);
        Task<bool> ValidateTokenAsync(string token);
    }
}