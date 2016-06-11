using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Model;
namespace Ticket_to_ride.Services
{
    class Game
    {
        Map map;
        public void start()
        {
            map = new MapGenerator().CreateMap();
            Ai computerOne = new Ai(map.getLocation(0), map.getLocation(4));

            computerOne.performTurn(map);
            computerOne.performTurn(map);
            computerOne.performTurn(map);
            computerOne.performTurn(map);
        }

        public Map getMap()
        {
            return map;
        }

    }
}
