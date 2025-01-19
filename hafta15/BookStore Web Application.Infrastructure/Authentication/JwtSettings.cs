using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public string? SecretKey { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public int ExpirationInMinutes { get; set; }
        public int RefreshTokenExpirationInDays { get; set; }
    }
}
