using System;
using System.Runtime.Caching;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Repository
{
    public class CachedRouteDeckRepository
    {
         private readonly RouteDeckRepository _routeDeckRepository;
        readonly MemoryCache _memoryCache;

        public CachedRouteDeckRepository()
        {
            _routeDeckRepository = new RouteDeckRepository();
            _memoryCache =  MemoryCache.Default;
        }

        public RouteCardDeck TryUpdate(RouteCardDeck routeCardDeck)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTime.Now.AddMinutes(30));
            _memoryCache.Set(CacheKeys.RouteDeckCacheKey, routeCardDeck, dateTimeOffset);
            return routeCardDeck;
        }

        public RouteCardDeck Load()
        {
            if (_memoryCache.Contains(CacheKeys.RouteDeckCacheKey))
            {
                return (RouteCardDeck)_memoryCache.Get(CacheKeys.RouteDeckCacheKey);
            }
            RouteCardDeck routeCardDeck = _routeDeckRepository.Load();
            return TryUpdate(routeCardDeck);
        }
    }
}