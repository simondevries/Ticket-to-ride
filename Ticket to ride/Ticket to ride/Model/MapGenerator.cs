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
            _location.Add(new Location { Identifier = "1", X = 184, Y = 166 });
            _location.Add(new Location { Identifier = "2", X = 338, Y = 217 });
            _location.Add(new Location { Identifier = "3", X = 490, Y = 288 });
            _location.Add(new Location { Identifier = "4", X = 626, Y = 362 });
            _location.Add(new Location { Identifier = "5", X = 340, Y = 127 });
            _location.Add(new Location { Identifier = "6", X = 335, Y = 25 });
            _location.Add(new Location { Identifier = "7", X = 615, Y = 253 });
            _location.Add(new Location { Identifier = "8", X = 542, Y = 127 });
            _location.Add(new Location { Identifier = "9", X = 442, Y = 68 });
            _connections.Add(new Connection(_location[0], _location[1], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[1], _location[0], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[1], _location[4], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[4], _location[1], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[4], _location[5], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[5], _location[4], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[5], _location[8], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[8], _location[5], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[8], _location[7], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[7], _location[8], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[7], _location[6], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[6], _location[7], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[6], _location[3], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[3], _location[6], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[3], _location[2], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[2], _location[3], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[2], _location[1], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[1], _location[2], 1, ConnectionColour.Red));





            return new Map(_connections, _location);
        }

    }
}
