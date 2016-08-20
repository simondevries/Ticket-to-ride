using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;
using Ticket_to_ride.Services.Ai;

namespace Ticket_to_ride.Services
{
    public class PlayersBuilder
    {
        private int _numberOfHumans;
        private int _numberOfAi;
        private readonly TrainDeck _trainDeck;
        private readonly RouteCardDeck _routeDeck;
        private Map _map;
        private Logger _logger;

        public PlayersBuilder(TrainDeck trainDeck, RouteCardDeck routeDeck, Map map, Logger logger)
        {
            _routeDeck = routeDeck;
            _trainDeck = trainDeck;
            _map = map;
            _logger = logger;
        }

        public List<Player> Build()
        {
            List<Player> players = new List<Player>();
            BrushBuilder brushBuilder = new BrushBuilder();

            int playerId = 0;
            for (int i = 0; i < _numberOfHumans; i++)
            {
                PlayerRouteHand routeCardsForPlayer = new PlayerRouteHand(_routeDeck.PullStartingFourRouteCardsForHuman());
                players.Add(new Human(routeCardsForPlayer, playerId++, brushBuilder. GetNextColour(), _trainDeck));

            }

            for (int i = 0; i < _numberOfAi; i++)
            {
                int currentPlayerId = playerId++;
                _logger.Log("Building player " + currentPlayerId, LogType.Debug);
                AiPlayerPersonalities aiPlayerPersonality = new AiPlayerPersonalities();
                PlayerRouteHand routeCardsForPlayer = new AiRouteCardPicker().PickFourRouteCards(_map, currentPlayerId, new List<int> { Int32.MaxValue }, aiPlayerPersonality, _logger);
                players.Add(new Ai.Ai(routeCardsForPlayer, currentPlayerId, brushBuilder.GetNextColour(), _trainDeck, aiPlayerPersonality));

            }


            _trainDeck.DealHands(players);    
         
            return players;
            
        }


        public PlayersBuilder WithAi(int numberOfAi)
        {
            _numberOfAi = numberOfAi;
            return this;
        }

        public PlayersBuilder WithHumans(int numberOfHumans)
        {
            _numberOfHumans = numberOfHumans;
            return this;
        }
    }
}