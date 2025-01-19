using BookStore_Web_Application.Core.Interfaces.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BookStore_Web_Application.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<CacheService> _logger;

        public CacheService(IDistributedCache cache, ILogger<CacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            try
            {
                var value = await _cache.GetAsync(key);
                if (value == null)
                {
                    return default(T);
                }

                return JsonSerializer.Deserialize<T>(value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting value from cache for key: {key}");
                return default(T);
            }
        }


        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            try
            {
                var options = new DistributedCacheEntryOptions();
                if (expiration.HasValue)
                {
                    options.AbsoluteExpirationRelativeToNow = expiration;
                }

                var bytes = JsonSerializer.SerializeToUtf8Bytes(value);
                await _cache.SetAsync(key, bytes, options);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting value in cache for key: {key}");
            }
        }

        public async Task RemoveAsync(string key)
        {
            try
            {
                await _cache.RemoveAsync(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing value from cache for key: {key}");
            }
        }
    }
}
