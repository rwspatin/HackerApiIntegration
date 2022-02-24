using HakerNewsIntegration.Infra.Repository.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace HakerNewsIntegration.Infra.Repository
{
    internal class CacheRepository : ICacheRepository
    {
        private readonly IMemoryCache _memoryCache;
        public CacheRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Set<T>(string key, T value, int minutesExpiration = 10)
            => _memoryCache.Set(key, value, TimeSpan.FromMinutes(minutesExpiration));

        public bool TryGet<T>(string key, out T value)
            => _memoryCache.TryGetValue(key, out value);
    }
}
