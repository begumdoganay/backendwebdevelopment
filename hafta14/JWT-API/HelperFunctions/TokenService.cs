using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JWT_API.DTOs;
using JWT_API.Models;

namespace JWT_API.HelperFunctions
{
    // Token oluşturma ve yönetme işlemlerini sağlayan servis

    public sealed class TokenService(
        UserManager<User> userManager,
        IOptions<CustomTokenOptions> tokenOptions,
        IHttpContextAccessor httpContextAccessor)
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly CustomTokenOptions _customTokenOptions = tokenOptions.Value;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        // Güvenli refresh token oluşturur

        private string CreateRefreshToken
        {
            get
            {
                var numberBytes = new byte[32];
                using var random = RandomNumberGenerator.Create();
                random.GetBytes(numberBytes);

                // Base64 URL safe string oluştur
                return Convert.ToBase64String(numberBytes)
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .Replace("=", "");
            }
        }

        // Kullanıcı için claim'leri oluşturur

        private async Task<IEnumerable<Claim>> GetClaimsAsync(User user, List<string> audiences)
        {
            var userClaims = new List<Claim>
           {
               new(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new(ClaimTypes.Email, user.Email!),
               new(ClaimTypes.Name, user.UserName!),
               new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
           };

            // Kullanıcı rollerini ekle
            var userRoles = await _userManager.GetRolesAsync(user);
            userClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            // Audience claim'lerini ekle
            userClaims.AddRange(audiences.Select(audience => new Claim(JwtRegisteredClaimNames.Aud, audience)));

            // IP ve cihaz bilgisini ekle
            if (_httpContextAccessor.HttpContext != null)
            {
                userClaims.Add(new Claim("ip_address", GetIpAddress()));
                userClaims.Add(new Claim("user_agent", GetUserAgent()));
            }

            return userClaims;
        }

        // Kullanıcı için token oluşturur

        public async Task<Token> CreateTokenAsync(User user)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_customTokenOptions.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.UtcNow.AddMinutes(_customTokenOptions.RefreshTokenExpiration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_customTokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _customTokenOptions.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: await GetClaimsAsync(user, _customTokenOptions.Audience),
                signingCredentials: signingCredentials
            );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            return new Token
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken,
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration,
                TokenType = "Bearer",
                CreatedAt = DateTime.UtcNow,
                ClientIp = GetIpAddress(),
                DeviceInfo = GetUserAgent()
            };
        }

        // Token'ı doğrular

        public ClaimsPrincipal? ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_customTokenOptions.SecurityKey);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _customTokenOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudiences = _customTokenOptions.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }

        // Token'ı yeniler

        public async Task<Token> RefreshTokenAsync(string refreshToken, User user)
        {
            var newToken = await CreateTokenAsync(user);
            newToken.RefreshCount++;
            return newToken;
        }

        // IP adresini alır

        private string GetIpAddress()
        {
            if (_httpContextAccessor.HttpContext == null) return "unknown";

            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            return ip ?? "unknown";
        }


        // Tarayıcı bilgisini alır

        private string GetUserAgent()
        {
            if (_httpContextAccessor.HttpContext == null) return "unknown";

            return _httpContextAccessor.HttpContext.Request.Headers.UserAgent.ToString();
        }


        // Token'ı iptal eder

        public async Task RevokeTokenAsync(User user)
        {
            // Kullanıcının refresh token'ını sıfırla
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            await _userManager.UpdateAsync(user);
        }

        internal object CreateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
