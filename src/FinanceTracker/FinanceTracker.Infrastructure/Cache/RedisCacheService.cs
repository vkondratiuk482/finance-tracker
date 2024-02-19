using System.Text.Json;
using StackExchange.Redis;
using FinanceTracker.Domain.Common;

namespace FinanceTracker.Infrastructure.Cache;

public class RedisCacheService : ICacheService
{
    private readonly TimeSpan _defaultTtl = TimeSpan.FromMinutes(5);

    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var database = _connectionMultiplexer.GetDatabase();

        var value = await database.StringGetAsync(key);

        if (!value.HasValue)
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(value.ToString());
    }

    public async Task SetAsync(string key, object value, TimeSpan? ttl)
    {
        ttl ??= _defaultTtl;

        var serialized = JsonSerializer.Serialize(value);

        var database = _connectionMultiplexer.GetDatabase();

        await database.StringSetAsync(key, serialized, ttl);
    }
}
