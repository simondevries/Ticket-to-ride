using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services.Ai
{
    public class AiRouteCardPicker
    {
        public const int NumberOfRouteCardsToChooseFrom = 4;
        private List<List<int>> _fourRouteCardCombinations;
        private AiRouteCoordinator _aiRouteCoordinator;
        private AiNumberOfCardsToPickUpDecider _aiNumberOfCardsToPickUpDecider;

        public AiRouteCardPicker()
        {
            _aiRouteCoordinator = new AiRouteCoordinator();
            _fourRouteCardCombinations = new List<List<int>>
            {
                new List<int>{0,1,2,3}, 
                new List<int>{0,1,2},
                new List<int>{0,1,3},
                new List<int>{0,2,3},
                new List<int>{1,2,3},
                new List<int>{2,3},
                new List<int>{1,3},
                new List<int>{1,2},
            };
            _aiNumberOfCardsToPickUpDecider = new AiNumberOfCardsToPickUpDecider();
        }

        public void PickThreeRouteCards()
        {
            throw new NotImplementedException();
        }

        public PlayerRouteHand PickFourRouteCards(Map riskMap, RouteCardDeck routeCardDeck, int aiId, List<int> numberOfTrainsOtherPlayersHave, AiPlayerPersonalities currentAiPersonality, Logger logger)
        {
            List<RouteCard> cardsPulledFromTop = routeCardDeck.PullCardsFromTop(NumberOfRouteCardsToChooseFrom);
            List<List<Location>> allRouteCombinations = BuildAllRouteCombinations(cardsPulledFromTop, numberOfTrainsOtherPlayersHave, currentAiPersonality);
            List<Route> possibleSolutionRoute = new List<Route>();

            LogPickedUpRouteCards(aiId, logger, cardsPulledFromTop);

            foreach (List<Location> possibleSolution in allRouteCombinations)
            {
                // ie 1234, 1243, ..
                possibleSolutionRoute.Add(_aiRouteCoordinator.GenerateRoute(riskMap, aiId, possibleSolution, logger));
            }



            //Pick the cheapest combination
            //todo choose more cards if time allows.
            int cheapest = 0;
            //set to default
            int selectedRoute = 0;
            int index = 0;
            foreach (Route route in possibleSolutionRoute)
            {
                    if (route.Cost > cheapest)
                    {
                        selectedRoute = index;
                        cheapest = route.Cost;
                    }
                    index++;

//                    logger.Log(
//                        string.Format("Route {0} Cost {1}", route.ToString(), route.Cost), LogType.Debug);
                
            }

//            int numberOfCardsToPickup =
//_aiNumberOfCardsToPickUpDecider.ShouldPickUpMoreCards(numberOfTrainsOtherPlayersHave,
//currentAiPersonality) - 1;
            //wants a list of routeCards to be made froma  list of locations
            logger.Log(
                string.Format("Player {0} selected the following routecards", aiId), LogType.Debug);
            PlayerRouteHand routeCard = new PlayerRouteHand();
            foreach (int routeCardCombination in _fourRouteCardCombinations[selectedRoute])
            {
                routeCard.AddRoutes(cardsPulledFromTop[routeCardCombination]);
                LogSelectedRouteCards(aiId, logger, cardsPulledFromTop[routeCardCombination]);
            }

            return routeCard;
        }

        private List<List<Location>> BuildAllRouteCombinations(List<RouteCard> playerRouteHand, List<int> numberOfTrainsOtherPlayersHave, AiPlayerPersonalities aiPlayerPersonality)
        {
            List<List<Location>> destinationLocations = new List<List<Location>>();

 

            foreach (List<int> cardCombination in _fourRouteCardCombinations)
            {

                    List<Location> possibleSolution = new List<Location>();
                    foreach (int fourRouteCardCombination in cardCombination)
                    {
                        possibleSolution.Add(playerRouteHand[fourRouteCardCombination].GetStartLocation());
                        possibleSolution.Add(playerRouteHand[fourRouteCardCombination].GetEndLocation());

                    }
                    destinationLocations.Add(possibleSolution);
            }

            return destinationLocations;
        }

        private static void LogPickedUpRouteCards(int aiId, Logger logger, List<RouteCard> cards)
        {
            IEnumerable<string> enumerable = cards.Select(card => card.GetStartLocation() +" -> "+ card.GetEndLocation());
            logger.Log(string.Format("Player {0} picked up {1}", aiId, string.Join(" ", enumerable.ToArray())), LogType.Debug);
        }

        private static void LogSelectedRouteCards(int aiId, Logger logger, RouteCard cards)
        {
            logger.Log(
                string.Format("{0} -> {1}",cards.GetStartLocation(),
                    cards.GetEndLocation()), LogType.Debug);
        }
    }
}