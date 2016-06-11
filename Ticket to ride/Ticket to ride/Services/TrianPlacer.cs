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
        public const int inf = 9999;

        public static void placeTrain(Connection connection, Map map){
            map.setWeight(connection, 0);
        }
    }
}
