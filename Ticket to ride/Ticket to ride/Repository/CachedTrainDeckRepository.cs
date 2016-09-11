using System;
using System.Runtime.Caching;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Repository
{
    public class CachedTrainDeckRepository
    {
         private readonly TrainDeckRepository _trainDeckRepository;
        readonly MemoryCache _memoryCache;

        public CachedTrainDeckRepository()
        {
            _trainDeckRepository = new TrainDeckRepository();
            _memoryCache =  MemoryCache.Default;
        }

        public TrainDeck TryUpdate(TrainDeck trainDeck)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTime.Now.AddMinutes(30));
            _memoryCache.Set(CacheKeys.TrainDeckCacheKey, trainDeck, dateTimeOffset);
            return trainDeck;
        }

        public TrainDeck Load()
        {
            if (_memoryCache.Contains(CacheKeys.TrainDeckCacheKey))
            {
                return (TrainDeck)_memoryCache.Get(CacheKeys.TrainDeckCacheKey);
            }
            TrainDeck trainDeck = _trainDeckRepository.Load();
            return TryUpdate(trainDeck);
        }
    }
}