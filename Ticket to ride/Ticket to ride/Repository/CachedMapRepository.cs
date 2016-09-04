using System;
using System.Runtime.Caching;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Repository
{
    public class CachedMapRepository
    {
        private readonly MapRepository _mapRepository;
        readonly MemoryCache _memoryCache;

        public CachedMapRepository()
        {
            _mapRepository = new MapRepository();
            _memoryCache =  MemoryCache.Default;
        }

        public Map Update(Map map)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTime.Now.AddMinutes(30));
            _memoryCache.Add(CacheKeys.MapCacheKey, map, dateTimeOffset);
            return map;
        }

        public Map Load()
        {
            if (_memoryCache.Contains(CacheKeys.MapCacheKey))
            {
                return (Map) _memoryCache.Get(CacheKeys.MapCacheKey);
            }
            Map map = _mapRepository.Load();
            return Update(map);
        }
    }
}