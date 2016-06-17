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
            _location.Add(new Location { Identifier = "1", X = 205, Y = 109 });
            _location.Add(new Location { Identifier = "2", X = 200, Y = 349 });
            _location.Add(new Location { Identifier = "3", X = 653, Y = 351 });
            _location.Add(new Location { Identifier = "4", X = 621, Y = 101 });
            _location.Add(new Location { Identifier = "5", X = 469, Y = 99 });
            _location.Add(new Location { Identifier = "6", X = 476, Y = 226 });
            _location.Add(new Location { Identifier = "7", X = 635, Y = 211 });
            _location.Add(new Location { Identifier = "8", X = 90, Y = 348 });
            _location.Add(new Location { Identifier = "9", X = 89, Y = 275 });
            _location.Add(new Location { Identifier = "10", X = 90, Y = 208 });
            _location.Add(new Location { Identifier = "11", X = 86, Y = 143 });
            _connections.Add(new Connection(_location[4], _location[5], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[5], _location[4], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[5], _location[6], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[6], _location[5], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[6], _location[3], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[3], _location[6], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[3], _location[4], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[4], _location[3], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[4], _location[0], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[0], _location[4], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[0], _location[10], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[10], _location[0], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[10], _location[9], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[9], _location[10], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[9], _location[8], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[8], _location[9], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[8], _location[7], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[7], _location[8], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[7], _location[1], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[1], _location[7], 1, ConnectionColour.Orange));
            _location.Add(new Location { Identifier = "22", X = 429, Y = 339 });
            _connections.Add(new Connection(_location[1], _location[11], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[11], _location[1], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[11], _location[2], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[2], _location[11], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[2], _location[6], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[6], _location[2], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[1], _location[5], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[5], _location[1], 1, ConnectionColour.Undefined));






            return new Map(_connections, _location);
        }

    }
}
