using System;
using Ticket_to_ride.Model;
// ReSharper disable RedundantLogicalConditionalExpressionOperand


namespace Ticket_to_ride.Services
{
    static class TrianPlacer
    {
        public const int Inf = 10000;

        public static bool CanSuccessfullyPlaceTrain(Connection connection, Map map, Player owner, AiUndefindRouteCardSelector aiUndefindRouteCardSelector){
            try
            {
                
                if (owner._availableTrains > connection.Weight &&
                    owner._playerTrainHand.SpendCardsIfPossible(connection, owner._playerType, aiUndefindRouteCardSelector) ||
                    (Settings.PlayersCanAffordAnything))
                {
                    owner.UseTrains(connection.Weight);
                    map.setWeight(connection, 0);
                    map.setOwner(connection, owner);
                    return true;
                }
                return false;
            }
            catch (InvalidOperationException)
            {
                Console.Write(@"Tried to place train in invalid locaiton");
            }
            return false;
        }

    }
}
