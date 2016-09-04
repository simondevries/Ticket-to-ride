using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Repository
{
    public class CachedPlayersRepository
    {
         private readonly PlayersRepository _playersRepository;
        readonly MemoryCache _memoryCache;

        public CachedPlayersRepository()
        {
            _playersRepository = new PlayersRepository();
            _memoryCache =  MemoryCache.Default;
        }

        public List<Player> Update(List<Player> players)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTime.Now.AddMinutes(30));
            _memoryCache.Add(CacheKeys.PlayersCacheKey, players, dateTimeOffset);
            return players;
        }

        public List<Player> Load()
        {
            if (_memoryCache.Contains(CacheKeys.PlayersCacheKey))
            {
                return (List<Player>)_memoryCache.Get(CacheKeys.PlayersCacheKey);
            }
            List<Player> players = _playersRepository.Load();
            return Update(players);
        }
    }
}