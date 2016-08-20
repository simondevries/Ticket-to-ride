using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Forms;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    public class RouteCardDeckDto
    {
        public List<RouteCardDto> EasyRouteCards { get; set; }
        public List<RouteCardDto> HardRouteCards { get; set; }

        public RouteCardDeck Map()
        {
            List<RouteCard> easyRouteCards = EasyRouteCards.Select(card => card.Map()).ToList();
            List<RouteCard> hardRouteCards = HardRouteCards.Select(card => card.Map()).ToList();

            return new RouteCardDeck(easyRouteCards, hardRouteCards);
        }
    }

    public class RouteCardDeck
    {
        private readonly List<RouteCard> _easyRouteCards;
        private readonly List<RouteCard> _hardRouteCards;
        private const int EASY_DECK_SIZE = 30;
        private const int HARD_DECK_SIZE = 10;

        public RouteCardDeck(List<RouteCard> easyRouteCards, List<RouteCard> hardRouteCards)
        {
            _easyRouteCards = easyRouteCards;
            _hardRouteCards = hardRouteCards;
        }

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
                int startRouteNumber;
                int endRouteNumber;
                int cost;

                do
                {
                    startRouteNumber = random.Next(numberOfLocations);
                    endRouteNumber = random.Next(numberOfLocations);

                    ShortestPathGenerator shortestPathGenerator = new ShortestPathGenerator(map.getLocations(),
                        map.getConnections());

                    Dictionary<Location, Route> calculateMinCost =
                        shortestPathGenerator.CalculateMinCost(map.getLocation(startRouteNumber), 0);
                    cost = calculateMinCost[map.getLocation(endRouteNumber)].Cost;

                } while (cost < 5 || ((cost < 15 && isHard) || (cost > 15 && !isHard)));

                int points = cost;

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

        public RouteCardDeckDto Map()
        {
            List<RouteCardDto> easyRouteCards = _easyRouteCards.Select(card => card.Map()).ToList();
            List<RouteCardDto> hardRouteCards = _hardRouteCards.Select(card => card.Map()).ToList();


            return new RouteCardDeckDto
            {
                EasyRouteCards = easyRouteCards,
                HardRouteCards = hardRouteCards
            };
        }
    }
}