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
        private AiRouteCardPicker _routeCardPicker;
        private AiUndefindRouteCardSelector _aiUndefindRouteCardSelector;
        public PlayerTrainHand PerformTurn(Map riskMap, PlayerTrainHand hand, IAiPlayerPersonality aiPlayerPersonality, Ai ai, TrainDeck deck)
        {
            _trainCardPicker = new AiTrainCardPicker();
            _aiUndefindRouteCardSelector = new AiUndefindRouteCardSelector(hand);
            //PickupRouteCards
            if (riskMap.getConnections().OrderByDescending(conn => conn.Risk).FirstOrDefault().Risk == 0)
            {
                //Get Route Cards


            }

            List<Connection> preferredConnections = GetPreferredRoutes(riskMap, aiPlayerPersonality);

            IEnumerable<CardType> preferredCardTypes = preferredConnections.Select(
                connection => ConnectionColourComparer.GetCardTypeFromConnectionColour(connection._colour));

            _aiUndefindRouteCardSelector.SetPreferredCardTypes(preferredCardTypes);
            bool successfullyPlacedTrain = CanSuccessfullyPlaceTrain(riskMap, hand, ai, preferredConnections);

            if (!successfullyPlacedTrain)
            {
                _trainCardPicker.PickCard(deck, preferredConnections, hand);
            }
            return hand;
        }


        public bool CanSuccessfullyPlaceTrain(Map riskMap, PlayerTrainHand hand, Ai ai, List<Connection> urgentActionCards )
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
                if (TrianPlacer.CanSuccessfullyPlaceTrain(urgentActionCard, riskMap, ai, _aiUndefindRouteCardSelector))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Connection> GetPreferredRoutes(Map riskMap, IAiPlayerPersonality aiPlayerPersonality)
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
                    aiPlayerPersonality.RiskDifferenceBetweenConnectionsToConsiderWorthOfSavingUpFor() && connections[i].Risk != 0)
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