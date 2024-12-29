using Microsoft.Build.Framework;

namespace JWT_API.DTOs
{
    public sealed record Login
    {
        [Required]
        public string Email { get; init; } = string.Empty;
        [Required]
        public string Password { get; init; } = string.Empty;
    }
}