using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    class MapGenerator
    {
        List<Connection> _connections = new List<Connection>();
        List<Location> _location = new List<Location>();

        public Map CreateMap()
        {

            Location locOne = new Location { Identifier = "0" };
            Location locTwo = new Location { Identifier = "1" };
            Location locThree = new Location { Identifier = "2" };
            Location locFour = new Location { Identifier = "3" };
            Location locFive = new Location { Identifier = "4" };
            Location locSix = new Location { Identifier = "5" };
            Location locSeven = new Location { Identifier = "6" };
            Location locEight = new Location { Identifier = "7" };
            Location locNine = new Location { Identifier = "8" };
            _location = new List<Location>{
                locOne,locTwo,locThree,locFour,locFive,locSix,locSeven,locEight,locNine
            };

            _connections.Add(new Connection(_location[0], _location[1], 1));
            _connections.Add(new Connection(_location[1], _location[0], 1));

            _connections.Add(new Connection(_location[1], _location[2], 1));
            _connections.Add(new Connection(_location[2], _location[1], 1));

            _connections.Add(new Connection(_location[2], _location[3], 1));
            _connections.Add(new Connection(_location[3], _location[2], 1));

            _connections.Add(new Connection(_location[3], _location[4], 1));
            _connections.Add(new Connection(_location[4], _location[3], 1));

            _connections.Add(new Connection(_location[3], _location[5], 1));
            _connections.Add(new Connection(_location[5], _location[3], 1));

            _connections.Add(new Connection(_location[6], _location[5], 1));
            _connections.Add(new Connection(_location[5], _location[6], 1));

            _connections.Add(new Connection(_location[7], _location[6], 1));
            _connections.Add(new Connection(_location[6], _location[7], 1));

            _connections.Add(new Connection(_location[8], _location[7], 1));
            _connections.Add(new Connection(_location[7], _location[8], 1));

            _connections.Add(new Connection(_location[1], _location[8], 1));
            _connections.Add(new Connection(_location[8], _location[1], 1));

            return new Map(_connections, _location);
        }

    }
}
