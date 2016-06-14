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
            _location.Add(new Location { Identifier = "1", X = 152, Y = 194 });
            _location.Add(new Location { Identifier = "2", X = 292, Y = 195 });
            _location.Add(new Location { Identifier = "3", X = 412, Y = 198 });
            _location.Add(new Location { Identifier = "4", X = 525, Y = 204 });
            _location.Add(new Location { Identifier = "5", X = 638, Y = 205 });
            _location.Add(new Location { Identifier = "6", X = 415, Y = 398 });
            _location.Add(new Location { Identifier = "7", X = 415, Y = 294 });
            _location.Add(new Location { Identifier = "8", X = 411, Y = 110 });
            _location.Add(new Location { Identifier = "9", X = 405, Y = 53 });
            _connections.Add(new Connection(_location[0], _location[1], 1));
            _connections.Add(new Connection(_location[1], _location[0], 1));
            _connections.Add(new Connection(_location[1], _location[2], 1));
            _connections.Add(new Connection(_location[2], _location[1], 1));
            _connections.Add(new Connection(_location[2], _location[3], 1));
            _connections.Add(new Connection(_location[3], _location[2], 1));
            _connections.Add(new Connection(_location[3], _location[4], 1));
            _connections.Add(new Connection(_location[4], _location[3], 1));
            _connections.Add(new Connection(_location[3], _location[6], 1));
            _connections.Add(new Connection(_location[6], _location[3], 1));
            _connections.Add(new Connection(_location[6], _location[1], 1));
            _connections.Add(new Connection(_location[1], _location[6], 1));
            _connections.Add(new Connection(_location[8], _location[7], 1));
            _connections.Add(new Connection(_location[7], _location[8], 1));
            _connections.Add(new Connection(_location[7], _location[2], 1));
            _connections.Add(new Connection(_location[2], _location[7], 1));
            _connections.Add(new Connection(_location[2], _location[6], 1));
            _connections.Add(new Connection(_location[6], _location[2], 1));
            _connections.Add(new Connection(_location[6], _location[5], 1));
            _connections.Add(new Connection(_location[5], _location[6], 1));




            return new Map(_connections, _location);
        }

    }
}
