using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Services;
using Ticket_to_ride.Services.Ai;

namespace Ticket_to_ride.Model
{
    /// <summary>
    /// responsible for placing the train if there is a high enough risk or otherwise pickling up the desired turn
    /// </summary>
    class AiTurnDecider
    {
        private AiTrainCardPicker _trainCardPicker;
        private readonly AiRouteCardPicker _routeCardPicker;
        private AiUndefindRouteCardSelector _aiUndefindRouteCardSelector;

        public AiTurnDecider()
        {
            _routeCardPicker = new AiRouteCardPicker();
        }

        public PlayerTrainHand PerformTurn(PlayerRouteHand finishdRouteCards, Map riskMap, PlayerTrainHand playerTrainHand, AiPlayerPersonalities aiPlayerPersonality, Ai ai, PlayerRouteHand playerRouteHand, List<int> numberOfTrainsOtherPlayersHave, Logger logger, RouteCardDeck routeCardDeck, TrainDeck trainDeck)
        {
            _trainCardPicker = new AiTrainCardPicker();
            _aiUndefindRouteCardSelector = new AiUndefindRouteCardSelector(playerTrainHand);

            bool pickedUpRouteCards = PickRouteCardsIfNecessairy(finishdRouteCards, riskMap, aiPlayerPersonality, ai, playerRouteHand, numberOfTrainsOtherPlayersHave, logger, routeCardDeck);
            if (pickedUpRouteCards)
            {
                //end turn
                return playerTrainHand;
            }


            List<Connection> preferredConnections = GetPreferredRoutes(riskMap, aiPlayerPersonality);

            IEnumerable<CardType> preferredCardTypes = preferredConnections.Select(
                connection => ConnectionColourComparer.GetCardTypeFromConnectionColour(connection._colour));

            _aiUndefindRouteCardSelector.SetPreferredCardTypes(preferredCardTypes);
            bool successfullyPlacedTrain = CanSuccessfullyPlaceTrain(riskMap, playerTrainHand, ai, preferredConnections, trainDeck);

            if (!successfullyPlacedTrain)
            {
                _trainCardPicker.PickCard(preferredConnections, playerTrainHand);
            }
            return playerTrainHand;
        }

        private bool PickRouteCardsIfNecessairy(PlayerRouteHand finishdRouteCards, Map riskMap, AiPlayerPersonalities aiPlayerPersonality, Ai ai, PlayerRouteHand playerRouteHand, List<int> numberOfTrainsOtherPlayersHave, Logger logger, RouteCardDeck routeCardDeck)
        {
//PickupRouteCards
            if (riskMap.getConnections().OrderByDescending(conn => conn.Risk).FirstOrDefault().Risk == 0)
            {

                logger.Log(
                    string.Format("Player {0} picks up more train cards", ai._id), LogType.Debug);
                finishdRouteCards.AddRoutes(playerRouteHand.GetRoutes());
                playerRouteHand.ClearRoutes();
                //todo make it pick three cards
                List<RouteCard> newRouteCards =
                    _routeCardPicker.PickFourRouteCards(riskMap, routeCardDeck, ai._id, numberOfTrainsOtherPlayersHave,
                        aiPlayerPersonality, logger).GetRoutes();
                playerRouteHand.AddRoutes(newRouteCards);
                return true;
            }
            return false;
        }


        public bool CanSuccessfullyPlaceTrain(Map riskMap, PlayerTrainHand hand, Ai ai, List<Connection> urgentActionCards, TrainDeck trainDeck )
        {
            //Order
            //Get top three and remove dups
            //if difference > SETAMOUNT then remove
            //if can build, 
            //      then build
            //else
            //      save, disregaurd other cards


            //Try and place any card of the same risk value
            foreach (Connection urgentActionCard in urgentActionCards)
            {
                if (TrianPlacer.CanSuccessfullyPlaceTrain(urgentActionCard, riskMap, ai, _aiUndefindRouteCardSelector, trainDeck))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Connection> GetPreferredRoutes(Map riskMap, AiPlayerPersonalities aiPlayerPersonality)
        {
//cases
            //High, High, High, High => 4th High excluded
            //High, Low, Low, Low -> 1st only
            //High, Med, Low, None -> All
            //None, None, None, None -> Random

            List<Connection> connections = riskMap.getConnections().OrderByDescending(conn => conn.Risk).ToList();
            connections = RemoveDuplicateConnections(connections);
            List<Connection> urgentActionCards;
            //todo: bug when there a an inf connecton and an inf connection with weight two

            //Always add the first card
            urgentActionCards = new List<Connection> {connections[0]};

            //if there is a difference in risk between two cards then add it to urgent
            for (int i = 1; i < connections.Count; i++)
            {
                if (connections[i - 1].Risk - connections[i].Risk <
                    aiPlayerPersonality.RiskDifferenceBetweenConnectionsToConsiderWorthOfSavingUpFor && connections[i].Risk != 0)
                {
                    urgentActionCards.Add(connections[i]);
                }
                else
                {
                    break;
                }
            }
            return urgentActionCards;
        }

        private List<Connection> RemoveDuplicateConnections(List<Connection> connections)
        {
            List<Connection> duplicateFreeConnections = new List<Connection>();
            foreach (Connection connection in connections)
            {
                bool foundDuplicate = false;
                foreach (Connection dupFreeConnection in duplicateFreeConnections)
                {
                    if (connection.HasSameStartAndEnd(dupFreeConnection))
                    {
                        foundDuplicate = true;
                        break;
                    }
                }
                if (!foundDuplicate)
                {
                    duplicateFreeConnections.Add(connection);
                }
            }
            return duplicateFreeConnections;
        }
    }
}