namespace JWT_API.DTOs
{

    // JWT token yapılandırması için kullanılan kayıt sınıfı
    public sealed record CustomTokenOptions
    {
        // Token'ın hedef kitlesi (aud claim)

        public List<string> Audience { get; set; } = new();

        // Token'ı yayınlayan (iss claim) 
        public string Issuer { get; set; } = string.Empty;
        // Access token'ın geçerlilik süresi (dakika)
        public int AccessTokenExpiration { get; set; }

        // Refresh token'ın geçerlilik süresi (dakika)
        public int RefreshTokenExpiration { get; set; }
        // Token imzalama için kullanılan güvenlik anahtarı

        public string SecurityKey { get; set; } = string.Empty;

        // Token'ın ne zaman yayınlandığı (iat claim)

        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        // Token'ın hangi zamandan önce geçerli olmadığı (nbf claim)

        public DateTime NotBefore { get; set; } = DateTime.UtcNow;
        // Token'ın benzersiz tanımlayıcısı (jti claim)
        public string TokenId { get; set; } = Guid.NewGuid().ToString();
        // Şifreleme algoritması

        public string SecurityAlgorithm { get; set; } = "HS256";
        // Token tipi (JWT)
        public string TokenType { get; set; } = "Bearer";
        // Refresh token uzunluğu

        public int RefreshTokenLength { get; set; } = 32;

        // Token yenileme limitini belirtir (kaç kez yenilenebilir)
        public int RefreshTokenTTL { get; set; } = 2;

        // Token için ek güvenlik özellikleri>
        public TokenSecurityOptions SecurityOptions { get; set; } = new();
    }

    // Token güvenlik ayarları için ek özellikler
    public sealed record TokenSecurityOptions
    {
        // IP bazlı doğrulama yapılıp yapılmayacağı
        public bool ValidateIssuer { get; set; } = true;

     
        // Hedef kitle doğrulaması yapılıp yapılmayacağı
       
        public bool ValidateAudience { get; set; } = true;
        // Yaşam süresinin kontrol edilip edilmeyeceği
     
        public bool ValidateLifetime { get; set; } = true;
        // İmza doğrulaması yapılıp yapılmayacağı
    
        public bool ValidateIssuerSigningKey { get; set; } = true;
        // Token zaman toleransı (saniye)
       
        public int ClockSkew { get; set; } = 5;
    }
}