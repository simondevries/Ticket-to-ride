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
            _location.Add(new Location { Identifier = "1", X = 286, Y = 425 });
            _location.Add(new Location { Identifier = "2", X = 376, Y = 431 });
            _location.Add(new Location { Identifier = "3", X = 279, Y = 360 });
            _location.Add(new Location { Identifier = "4", X = 375, Y = 351 });
            _location.Add(new Location { Identifier = "5", X = 336, Y = 293 });
            _location.Add(new Location { Identifier = "6", X = 414, Y = 238 });
            _location.Add(new Location { Identifier = "7", X = 391, Y = 200 });
            _location.Add(new Location { Identifier = "8", X = 449, Y = 127 });
            _location.Add(new Location { Identifier = "9", X = 377, Y = 48 });
            _location.Add(new Location { Identifier = "10", X = 275, Y = 56 });
            _location.Add(new Location { Identifier = "11", X = 518, Y = 120 });
            _location.Add(new Location { Identifier = "12", X = 717, Y = 142 });
            _location.Add(new Location { Identifier = "13", X = 528, Y = 200 });
            _location.Add(new Location { Identifier = "14", X = 656, Y = 305 });
            _location.Add(new Location { Identifier = "15", X = 701, Y = 192 });
            _location.Add(new Location { Identifier = "16", X = 483, Y = 335 });
            _location.Add(new Location { Identifier = "17", X = 636, Y = 446 });
            _location.Add(new Location { Identifier = "18", X = 759, Y = 458 });
            _location.Add(new Location { Identifier = "19", X = 800, Y = 366 });
            _location.Add(new Location { Identifier = "20", X = 800, Y = 206 });
            _connections.Add(new Connection(_location[0], _location[1], 1));
            _connections.Add(new Connection(_location[1], _location[0], 1));
            _connections.Add(new Connection(_location[1], _location[3], 1));
            _connections.Add(new Connection(_location[3], _location[1], 1));
            _connections.Add(new Connection(_location[3], _location[2], 1));
            _connections.Add(new Connection(_location[2], _location[3], 1));
            _connections.Add(new Connection(_location[2], _location[0], 1));
            _connections.Add(new Connection(_location[0], _location[2], 1));
            _connections.Add(new Connection(_location[0], _location[3], 1));
            _connections.Add(new Connection(_location[3], _location[0], 1));
            _connections.Add(new Connection(_location[3], _location[15], 1));
            _connections.Add(new Connection(_location[15], _location[3], 1));
            _connections.Add(new Connection(_location[15], _location[16], 1));
            _connections.Add(new Connection(_location[16], _location[15], 1));
            _connections.Add(new Connection(_location[16], _location[17], 1));
            _connections.Add(new Connection(_location[17], _location[16], 1));
            _connections.Add(new Connection(_location[17], _location[18], 1));
            _connections.Add(new Connection(_location[18], _location[17], 1));
            _connections.Add(new Connection(_location[18], _location[13], 1));
            _connections.Add(new Connection(_location[13], _location[18], 1));
            _connections.Add(new Connection(_location[13], _location[16], 1));
            _connections.Add(new Connection(_location[16], _location[13], 1));
            _connections.Add(new Connection(_location[13], _location[12], 1));
            _connections.Add(new Connection(_location[12], _location[13], 1));
            _connections.Add(new Connection(_location[12], _location[15], 1));
            _connections.Add(new Connection(_location[15], _location[12], 1));
            _connections.Add(new Connection(_location[15], _location[5], 1));
            _connections.Add(new Connection(_location[5], _location[15], 1));
            _connections.Add(new Connection(_location[5], _location[6], 1));
            _connections.Add(new Connection(_location[6], _location[5], 1));
            _connections.Add(new Connection(_location[6], _location[7], 1));
            _connections.Add(new Connection(_location[7], _location[6], 1));
            _connections.Add(new Connection(_location[7], _location[12], 1));
            _connections.Add(new Connection(_location[12], _location[7], 1));
            _connections.Add(new Connection(_location[12], _location[10], 1));
            _connections.Add(new Connection(_location[10], _location[12], 1));
            _connections.Add(new Connection(_location[10], _location[7], 1));
            _connections.Add(new Connection(_location[7], _location[10], 1));
            _connections.Add(new Connection(_location[10], _location[14], 1));
            _connections.Add(new Connection(_location[14], _location[10], 1));
            _connections.Add(new Connection(_location[14], _location[12], 1));
            _connections.Add(new Connection(_location[12], _location[14], 1));
            _connections.Add(new Connection(_location[19], _location[14], 1));
            _connections.Add(new Connection(_location[14], _location[19], 1));
            _connections.Add(new Connection(_location[14], _location[11], 1));
            _connections.Add(new Connection(_location[11], _location[14], 1));
            _connections.Add(new Connection(_location[11], _location[7], 1));
            _connections.Add(new Connection(_location[7], _location[11], 1));
            _connections.Add(new Connection(_location[7], _location[8], 1));
            _connections.Add(new Connection(_location[8], _location[7], 1));
            _connections.Add(new Connection(_location[8], _location[9], 1));
            _connections.Add(new Connection(_location[9], _location[8], 1));
            _connections.Add(new Connection(_location[2], _location[4], 1));
            _connections.Add(new Connection(_location[4], _location[2], 1));
            _connections.Add(new Connection(_location[4], _location[6], 1));
            _connections.Add(new Connection(_location[6], _location[4], 1));
            _connections.Add(new Connection(_location[3], _location[4], 1));
            _connections.Add(new Connection(_location[4], _location[3], 1));
            _connections.Add(new Connection(_location[4], _location[5], 1));
            _connections.Add(new Connection(_location[5], _location[4], 1));




            return new Map(_connections, _location);
        }

    }
}
