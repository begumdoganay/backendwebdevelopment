using System.Text.Json.Serialization;

namespace JWT_API.DTOs
{
    // Token bilgilerini taşıyan DTO sınıfı
    public sealed class Token
    {
        // Access token değeri

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = string.Empty;
        // Access token'ın son geçerlilik tarihi

        [JsonPropertyName("access_token_expiration")]
        public DateTime AccessTokenExpiration { get; set; }
        // Refresh token değeri

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = string.Empty;
        // Refresh token'ın son geçerlilik tarihi

        [JsonPropertyName("refresh_token_expiration")]
        public DateTime RefreshTokenExpiration { get; set; }
        // Token tipi (Bearer)

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = "Bearer";
        // Token'ın oluşturulma tarihi
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Token'ın yenilenme sayısı
        [JsonPropertyName("refresh_count")]
        public int RefreshCount { get; set; } = 0;
        // Token'ın oluşturulduğu IP adresi
        [JsonPropertyName("client_ip")]

        public string? ClientIp { get; set; }
        // Token'ın oluşturulduğu cihaz bilgisi
        [JsonPropertyName("device_info")]

        public string? DeviceInfo { get; set; }
        // Access token için kalan süre (saniye)
        [JsonIgnore]

        public int AccessTokenRemainingTime => (int)(AccessTokenExpiration - DateTime.UtcNow).TotalSeconds;
        // Refresh token için kalan süre (saniye)
        [JsonIgnore]

        public int RefreshTokenRemainingTime => (int)(RefreshTokenExpiration - DateTime.UtcNow).TotalSeconds;
        // Access token'ın süresi dolmuş mu?
        [JsonIgnore]

        public bool IsAccessTokenExpired => DateTime.UtcNow >= AccessTokenExpiration;
        // Refresh token'ın süresi dolmuş mu?
        [JsonIgnore]

        public bool IsRefreshTokenExpired => DateTime.UtcNow >= RefreshTokenExpiration;
        // Token'ın yenilenebilir olup olmadığı
        [JsonPropertyName("is_refreshable")]

        public bool IsRefreshable => !IsRefreshTokenExpired && RefreshCount < MaxRefreshCount;
        // Maksimum yenilenme sayısı
        [JsonIgnore]

        public static int MaxRefreshCount { get; set; } = 5;
        // Token özet bilgisi

        public string GetSummary()
        {
            return $"Access Token: {AccessToken[..10]}... " +
                   $"(Expires in {AccessTokenRemainingTime} seconds), " +
                   $"Refresh Token: {RefreshToken[..10]}... " +
                   $"(Expires in {RefreshTokenRemainingTime} seconds)";
        }
    }
}