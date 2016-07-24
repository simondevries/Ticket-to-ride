using System.Collections.Generic;
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
        private readonly TurnCoordinator _turnCoordinator;

        public PlayersBuilder(TrainDeck trainDeck, RouteCardDeck routeDeck, TurnCoordinator turnCoordinator)
        {
            _routeDeck = routeDeck;
            _trainDeck = trainDeck;
            _turnCoordinator = turnCoordinator;
        }

        public List<Player> Build()
        {
            List<Player> players = new List<Player>();
            BrushBuilder brushBuilder = new BrushBuilder();

            int playerId = 0;
            for (int i = 0; i < _numberOfHumans; i++)
            {
                PlayerRouteHand routeCardsForPlayer = new PlayerRouteHand(_routeDeck.PullStartingFourRouteCards());
                players.Add(new Human(routeCardsForPlayer, playerId++, brushBuilder. GetNextColour(), _trainDeck));
            }

            for (int i = 0; i < _numberOfAi; i++)
            {
                PlayerRouteHand routeCardsForPlayer = new PlayerRouteHand(_routeDeck.PullStartingFourRouteCards());
                IAiPlayerPersonality aiPlayerPersonality = new AiPlayerPersonalitySaveCards();
                players.Add(new Ai.Ai(routeCardsForPlayer, playerId++, brushBuilder.GetNextColour(), _trainDeck, aiPlayerPersonality, _turnCoordinator));
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