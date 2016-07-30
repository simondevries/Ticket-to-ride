using System;
using System.Collections.Generic;
using Ticket_to_ride.Forms;

namespace Ticket_to_ride.Model
{
    public class RouteCardDeck
    {
        private List<RouteCard> _easyRouteCards;
        private List<RouteCard> _hardRouteCards;
        private const int EASY_DECK_SIZE = 30;
        private const int HARD_DECK_SIZE = 10;
        public RouteCardDeck(Map map)
        {
            int numberOfLocations = map.GetNumberOfLocations();

            _easyRouteCards = new List<RouteCard>();
            _hardRouteCards = new List<RouteCard>();

            Random random = new Random();
            CreateDeck(map, numberOfLocations, EASY_DECK_SIZE, _easyRouteCards, false, random);
            CreateDeck(map, numberOfLocations, HARD_DECK_SIZE, _hardRouteCards, true, random);
        }

        private void CreateDeck(Map map, int numberOfLocations, int deckSize, List<RouteCard> deck, bool isHard, Random random)
        {
            //todo If ti si a hard route then make sure it is harder
            for (int i = 0; i < deckSize; i++)
            {
                int startRouteNumber = random.Next(numberOfLocations);
                int endRouteNumber = random.Next(numberOfLocations);
                int points = random.Next(20);

                RouteCard routeCard = new RouteCard(map.getLocation(startRouteNumber), map.getLocation(endRouteNumber), isHard, points);
                deck.Add(routeCard);
            }
        }

        public List<RouteCard> PullStartingFourRouteCardsForHuman()
        {
            List<RouteCard> routeCards = PullCardsFromTop(4);


            RouteTaskSelectorForm routeTaskSelectorForm = new RouteTaskSelectorForm(routeCards[0], routeCards[1], routeCards[2], routeCards[3], true, RouteCardSelectorState.InitialPickup);
            routeTaskSelectorForm.ShowDialog();

            return routeTaskSelectorForm.SelectedRouteCards;
        }

        public List<RouteCard> PullNonStartingFourRouteCardsForHuman()
        {
            List<RouteCard> routeCards = PullCardsFromTop(3);

            RouteTaskSelectorForm routeTaskSelectorForm = new RouteTaskSelectorForm(routeCards[0], routeCards[1], routeCards[2], null, false, RouteCardSelectorState.InGamePickup);
            routeTaskSelectorForm.ShowDialog();

            return routeTaskSelectorForm.SelectedRouteCards;
        }

        public List<RouteCard> PullCardsFromTop(int numberOfCards)
        {
            List<RouteCard> routeCards = new List<RouteCard>();
            for (int i = 0; i < numberOfCards; i++)
            {
                routeCards.Add(_easyRouteCards[0]);
                _easyRouteCards.RemoveAt(0);
            }
            return routeCards;
        }
    }
}