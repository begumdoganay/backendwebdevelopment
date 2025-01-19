using BookStore_Web_Application.Core.Dtos.Authentication;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Exceptions;
using BookStore_Web_Application.Core.Interfaces.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookStore_Web_Application.Infrastructure.Authentication
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ILogger<IdentityService> _logger;

        public IdentityService(
            UserManager<User> userManager,
            IJwtTokenGenerator jwtTokenGenerator,
            ILogger<IdentityService> logger)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _logger = logger;
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    _logger.LogWarning($"Login attempt failed for email: {email} - User not found");
                    throw new UnauthorizedException("Geçersiz email veya şifre");
                }

                var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
                if (!isPasswordValid)
                {
                    _logger.LogWarning($"Login attempt failed for email: {email} - Invalid password");
                    throw new UnauthorizedException("Geçersiz email veya şifre");
                }

                var roles = await _userManager.GetRolesAsync(user);
                var accessToken = _jwtTokenGenerator.GenerateToken(user, roles);
                var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _userManager.UpdateAsync(user);

                _logger.LogInformation($"User {email} logged in successfully");

                return new AuthenticationResult
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresIn = DateTime.UtcNow.AddMinutes(30)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error during login process for email: {email}");
                throw;
            }
        }

        public async Task<AuthenticationResult> RefreshTokenAsync(string refreshToken)
        {
            try
            {
                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

                if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                {
                    _logger.LogWarning("Refresh token attempt failed - Invalid or expired token");
                    throw new UnauthorizedException("Geçersiz refresh token");
                }

                var roles = await _userManager.GetRolesAsync(user);
                var accessToken = _jwtTokenGenerator.GenerateToken(user, roles);
                var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _userManager.UpdateAsync(user);

                _logger.LogInformation($"Token refreshed successfully for user: {user.Email}");

                return new AuthenticationResult
                {
                    AccessToken = accessToken,
                    RefreshToken = newRefreshToken,
                    ExpiresIn = DateTime.UtcNow.AddMinutes(30)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during token refresh process");
                throw;
            }
        }

        public async Task RevokeTokenAsync(string refreshToken)
        {
            try
            {
                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

                if (user == null)
                {
                    _logger.LogWarning("Token revocation failed - Invalid token");
                    throw new UnauthorizedException("Geçersiz refresh token");
                }

                user.RefreshToken = null;
                user.RefreshTokenExpiryTime = null;
                await _userManager.UpdateAsync(user);

                _logger.LogInformation($"Token revoked successfully for user: {user.Email}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during token revocation process");
                throw;
            }
        }
    }
}