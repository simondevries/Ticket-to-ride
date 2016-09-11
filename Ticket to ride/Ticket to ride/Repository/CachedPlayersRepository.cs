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

        public List<Player> TryUpdate(List<Player> players)
        {

            PlayersDto playersDto = new PlayersDto(players);

            DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTime.Now.AddMinutes(30));
            _memoryCache.Set(CacheKeys.PlayersCacheKey, playersDto, dateTimeOffset);
            return players;
        }

        public List<Player> Load()
        {

            if (_memoryCache.Contains(CacheKeys.PlayersCacheKey))
            {
                return ((PlayersDto)_memoryCache.Get(CacheKeys.PlayersCacheKey)).Players;
            }
            List<Player> players = _playersRepository.Load();
            return TryUpdate(players);
        }
    }

    public class PlayersDto
    {
        public List<Player> Players;

        public PlayersDto(List<Player> players)
        {
            Players = players;
        }
    }
}