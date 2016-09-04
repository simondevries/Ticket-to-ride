using System;
using System.Runtime.Caching;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Repository
{
    public class CachedTurnRepository
    {
         private readonly TurnRepository _turnRepository;
        readonly MemoryCache _memoryCache;

        public CachedTurnRepository()
        {
            _turnRepository = new TurnRepository();
            _memoryCache =  MemoryCache.Default;
        }

        public TurnCoordinator Update(TurnCoordinator turnCoordinator)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTime.Now.AddMinutes(30));
            _memoryCache.Add(CacheKeys.TurnCacheKey, turnCoordinator, dateTimeOffset);
            return turnCoordinator;
        }

        public TurnCoordinator Load()
        {
            if (_memoryCache.Contains(CacheKeys.TurnCacheKey))
            {
                return (TurnCoordinator)_memoryCache.Get(CacheKeys.TurnCacheKey);
            }
            TurnCoordinator  turnCoordinator = _turnRepository.Load();
            return Update(turnCoordinator);
        }
    }
}