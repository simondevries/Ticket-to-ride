using System.Collections.Generic;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class PlayersBuilder
    {
        private int _numberOfHumans;
        private int _numberOfAi;
        private readonly TrainDeck _trainDeck;
        private RouteCardDeck _routeDeck;

        public PlayersBuilder(TrainDeck trainDeck, RouteCardDeck routeDeck)
        {
            _routeDeck = routeDeck;
            _trainDeck = trainDeck;
        }

        public List<Player> Build()
        {
            List<Player> players = new List<Player>();
            BrushBuilder brushBuilder = new BrushBuilder();


            for (int i = 0; i < _numberOfHumans; i++)
            {
                PlayerRouteHand routeCardsForPlayer = new PlayerRouteHand(_routeDeck.PullStartingFourRouteCards());
                players.Add(new Human(routeCardsForPlayer, i, brushBuilder. GetNextColour(), _trainDeck));
            }

            for (int i = 0; i < _numberOfAi; i++)
            {
                PlayerRouteHand routeCardsForPlayer = new PlayerRouteHand(_routeDeck.PullStartingFourRouteCards());
                players.Add(new Ai(routeCardsForPlayer, i, brushBuilder.GetNextColour(), _trainDeck));
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