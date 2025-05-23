using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nettium_Test.Application.Interfaces.Caching;
using StackExchange.Redis;
using System.Text.Json;

namespace Nettium_Test.Persistence.Caching
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase? _db;
        private readonly ILogger<RedisCacheService> _logger;
        private readonly bool _isRedisAvailable = true;

        public RedisCacheService(IConfiguration configuration,
            ILogger<RedisCacheService> logger)
        {
            _logger = logger;

            var connectionString = configuration.GetSection("Redis:ConnectionString").Value;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                _logger.LogWarning("Redis connection string is not configured.");
                _isRedisAvailable = false;
                return;
            }

            try
            {
                var redis = ConnectionMultiplexer.Connect(connectionString);
                _db = redis.GetDatabase();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to connect to Redis Server {connectionString}. Redis caching will be disabled.");
                _isRedisAvailable = false;
            }
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            if (!_isRedisAvailable || _db == null)
                return default;

            var value = await _db.StringGetAsync(key);
            return value.IsNullOrEmpty ? default : JsonSerializer.Deserialize<T>(value!);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            if (!_isRedisAvailable || _db == null)
                return;

            var json = JsonSerializer.Serialize(value);
            await _db.StringSetAsync(key, json, expiry);
        }

        public async Task<bool> RemoveAsync(string key)
        {
            if (!_isRedisAvailable || _db == null)
                return false;

            return await _db.KeyDeleteAsync(key);
        }
    }
}
