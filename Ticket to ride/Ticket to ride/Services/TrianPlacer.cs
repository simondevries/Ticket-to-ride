using System;
using Ticket_to_ride.Model;


namespace Ticket_to_ride.Services
{
    static class TrianPlacer
    {
        public const int Inf = 10000;

        public static bool PlaceTrain(Connection connection, Map map, Player owner){
            try
            {
                if (owner._availableTrains > connection.Weight &&
                    owner.PlayerTrainHand.SpendCardsIfPossible(connection))
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
