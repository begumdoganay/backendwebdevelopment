using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Interfaces.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookStore_Web_Application.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<JwtTokenGenerator> _logger;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings, ILogger<JwtTokenGenerator> logger)
        {
            _jwtSettings = jwtSettings?.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
            _logger = logger;
        }

        public string GenerateToken(User user, IList<string> roles)
        {
            try
            {
                if (string.IsNullOrEmpty(_jwtSettings.SecretKey))
                {
                    _logger.LogError("JWT SecretKey is not configured");
                    throw new InvalidOperationException("JWT SecretKey is not configured.");
                }

                if (user == null)
                {
                    _logger.LogError("User object is null");
                    throw new ArgumentNullException(nameof(user));
                }

                if (string.IsNullOrEmpty(user.Email))
                {
                    _logger.LogError($"Email is null for user ID: {user.Id}");
                    throw new ArgumentException("User email cannot be null or empty.", nameof(user.Email));
                }

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
               {
                   new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                   new Claim(JwtRegisteredClaimNames.Email, user.Email),
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName ?? string.Empty),
                   new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? string.Empty)
               };

                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        if (!string.IsNullOrEmpty(role))
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                    }
                }

                _logger.LogInformation($"Generating token for user: {user.Email}");
                _logger.LogDebug($"JWT Settings - Issuer: {_jwtSettings.Issuer}, Audience: {_jwtSettings.Audience}");

                var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
                    signingCredentials: credentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                _logger.LogInformation($"Token generated successfully for user: {user.Email}");

                return tokenString;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error generating JWT token for user: {user?.Email ?? "unknown"}");
                throw;
            }
        }

        public string GenerateRefreshToken()
        {
            try
            {
                var randomNumber = new byte[32];
                using var rng = RandomNumberGenerator.Create();
                rng.GetBytes(randomNumber);

                var refreshToken = Convert.ToBase64String(randomNumber);
                _logger.LogInformation("Refresh token generated successfully");

                return refreshToken;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating refresh token");
                throw;
            }
        }
    }
}