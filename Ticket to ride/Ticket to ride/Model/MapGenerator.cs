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

            _location.Add(new Location { Identifier = "1", X = 404, Y = 538 });
            _location.Add(new Location { Identifier = "2", X = 524, Y = 541 });
            _location.Add(new Location { Identifier = "3", X = 637, Y = 532 });
            _location.Add(new Location { Identifier = "4", X = 711, Y = 496 });
            _location.Add(new Location { Identifier = "5", X = 740, Y = 406 });
            _location.Add(new Location { Identifier = "6", X = 690, Y = 347 });
            _location.Add(new Location { Identifier = "7", X = 665, Y = 304 });
            _location.Add(new Location { Identifier = "8", X = 594, Y = 268 });
            _location.Add(new Location { Identifier = "9", X = 544, Y = 265 });
            _location.Add(new Location { Identifier = "10", X = 528, Y = 486 });
            _location.Add(new Location { Identifier = "11", X = 529, Y = 381 });
            _connections.Add(new Connection(_location[0], _location[1], 1));
            _connections.Add(new Connection(_location[1], _location[0], 1));
            _connections.Add(new Connection(_location[1], _location[2], 1));
            _connections.Add(new Connection(_location[2], _location[1], 1));
            _connections.Add(new Connection(_location[2], _location[3], 1));
            _connections.Add(new Connection(_location[3], _location[2], 1));
            _connections.Add(new Connection(_location[3], _location[4], 1));
            _connections.Add(new Connection(_location[4], _location[3], 1));
            _connections.Add(new Connection(_location[4], _location[5], 1));
            _connections.Add(new Connection(_location[5], _location[4], 1));
            _connections.Add(new Connection(_location[5], _location[6], 1));
            _connections.Add(new Connection(_location[6], _location[5], 1));
            _connections.Add(new Connection(_location[6], _location[7], 1));
            _connections.Add(new Connection(_location[7], _location[6], 1));
            _connections.Add(new Connection(_location[7], _location[8], 1));
            _connections.Add(new Connection(_location[8], _location[7], 1));
            _connections.Add(new Connection(_location[8], _location[10], 1));
            _connections.Add(new Connection(_location[10], _location[8], 1));
            _connections.Add(new Connection(_location[10], _location[9], 1));
            _connections.Add(new Connection(_location[9], _location[10], 1));
            _connections.Add(new Connection(_location[9], _location[1], 1));
            _connections.Add(new Connection(_location[1], _location[9], 1));







            return new Map(_connections, _location);
        }

    }
}
