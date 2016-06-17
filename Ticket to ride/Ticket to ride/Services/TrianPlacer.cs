using System;
using Ticket_to_ride.Model;


namespace Ticket_to_ride.Services
{
    static class TrianPlacer
    {
        public const int Inf = 10000;

        public static void PlaceTrain(Connection connection, Map map, Player owner){
            try
            {
                if (owner._availableTrains > connection.Weight &&
                    owner._hand.SpendCardsIfPossible(connection))
                {
                    map.setWeight(connection, 0);
                    map.setOwner(connection, owner);
                }
            }
            catch (InvalidOperationException)
            {
                Console.Write(@"Tried to place train in invalid locaiton");
            }
        }

    }
}
