using System.Collections.Generic;
using Ticket_to_ride.Model;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Repository
{
    public class GameRepository
    {
        public Game Build()
        {
            TrainDeck cachedTrainDeckRepository = new CachedTrainDeckRepository().Load();
            Map cachedMapRepository = new CachedMapRepository().Load();
            RouteCardDeck cachedRouteDeckRepository = new CachedRouteDeckRepository().Load();
            List<Player> cachedPlayersRepository = new CachedPlayersRepository().Load();
            TurnCoordinator cachedTurnRepository = new CachedTurnRepository().Load();

            Game game = new Game(cachedTurnRepository, cachedPlayersRepository, cachedTrainDeckRepository, cachedMapRepository, cachedRouteDeckRepository);

            return game;
        }

        public void CacheSave(Game game)
        {
            new CachedRouteDeckRepository().TryUpdate(game._routeCardDeck);
            new CachedMapRepository().TryUpdate(game._map);
            new CachedTrainDeckRepository().TryUpdate(game._trainDeck);
            new CachedTurnRepository().TryUpdate(game._turnCoordinator);
            new CachedPlayersRepository().TryUpdate(game._players);
        }

        public void Save(Game game)
        {
            new RouteDeckRepository().Update(game._routeCardDeck);
            new MapRepository().Update(game._map);
            new TrainDeckRepository().Update(game._trainDeck);
            new TurnRepository().Update(game._turnCoordinator);
            new PlayersRepository().Update(game._players);
        }
    }
}