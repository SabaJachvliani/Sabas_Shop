using Application.Interfaces.Auth;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastucture.Caching
{
    public sealed class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheService(IMemoryCache cache) => _cache = cache;

        public Task<T> GetOrCreateAsync<T>(
            string key,
            TimeSpan ttl,
            Func<CancellationToken, Task<T>> factory,
            CancellationToken ct)
        {
            return _cache.GetOrCreateAsync(key, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = ttl;
                return factory(ct);
            })!;
        }

        public void Remove(string key) => _cache.Remove(key);
    }
}
