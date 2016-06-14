using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Model;


namespace Ticket_to_ride.Services
{
    static class TrianPlacer
    {
        public const int inf = 10000;

        public static void placeTrain(Connection connection, Map map, Player owner){
            try
            {
                map.setWeight(connection, 0);
                map.setOwner(connection, owner);
            }
            catch (InvalidOperationException ex)
            {
                Console.Write("Tried to place train in invalid locaiton");
            }
        }
    }
}
