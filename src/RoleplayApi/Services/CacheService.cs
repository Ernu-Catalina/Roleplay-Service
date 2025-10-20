using StackExchange.Redis;
using System.Text.Json;

namespace RoleplayApi.Services
{
    public class CacheService
    {
        private readonly IDatabase _db;
        private readonly int _defaultTtl;

        public CacheService(IConnectionMultiplexer redis, IConfiguration config)
        {
            _db = redis.GetDatabase();
            _defaultTtl = config.GetValue<int>("CacheDefaultTtl", 15);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            if (value.IsNullOrEmpty) return default;
            return JsonSerializer.Deserialize<T>(value!);
        }

        public async Task SetAsync<T>(string key, T data, int? ttl = null)
        {
            var json = JsonSerializer.Serialize(data);
            await _db.StringSetAsync(key, json, TimeSpan.FromSeconds(ttl ?? _defaultTtl));
        }
    }
}
