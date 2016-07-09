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
            _location.Add(new Location { Identifier = "0", X = 266, Y = 225 });
            _location.Add(new Location { Identifier = "1", X = 391, Y = 226 });
            _location.Add(new Location { Identifier = "2", X = 531, Y = 232 });
            _location.Add(new Location { Identifier = "3", X = 622, Y = 236 });
            _location.Add(new Location { Identifier = "4", X = 707, Y = 236 });
            _location.Add(new Location { Identifier = "5", X = 398, Y = 297 });
            _location.Add(new Location { Identifier = "6", X = 384, Y = 366 });
            _location.Add(new Location { Identifier = "7", X = 393, Y = 429 });
            _location.Add(new Location { Identifier = "8", X = 398, Y = 506 });
            _location.Add(new Location { Identifier = "9", X = 565, Y = 413 });
            _location.Add(new Location { Identifier = "10", X = 540, Y = 310 });
            _location.Add(new Location { Identifier = "11", X = 631, Y = 313 });
            _location.Add(new Location { Identifier = "12", X = 620, Y = 152 });
            _connections.Add(new Connection(_location[0], _location[1], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[1], _location[0], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[1], _location[5], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[5], _location[1], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[5], _location[6], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[6], _location[5], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[6], _location[10], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[10], _location[6], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[10], _location[2], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[2], _location[10], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[2], _location[1], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[1], _location[2], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[2], _location[3], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[3], _location[2], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[3], _location[12], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[12], _location[3], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[12], _location[4], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[4], _location[12], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[4], _location[11], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[11], _location[4], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[11], _location[10], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[10], _location[11], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[9], _location[7], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[7], _location[9], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[7], _location[6], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[6], _location[7], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[7], _location[8], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[8], _location[7], 1, ConnectionColour.Black));






            return new Map(_connections, _location);
        }

    }
}
