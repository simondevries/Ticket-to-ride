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
            _location.Add(new Location { Identifier = "0", X = 235, Y = 561 });
            _location.Add(new Location { Identifier = "1", X = 237, Y = 650 });
            _location.Add(new Location { Identifier = "2", X = 318, Y = 660 });
            _location.Add(new Location { Identifier = "3", X = 338, Y = 558 });
            _location.Add(new Location { Identifier = "4", X = 355, Y = 438 });
            _location.Add(new Location { Identifier = "5", X = 428, Y = 384 });
            _location.Add(new Location { Identifier = "6", X = 457, Y = 337 });
            _location.Add(new Location { Identifier = "7", X = 529, Y = 331 });
            _location.Add(new Location { Identifier = "8", X = 534, Y = 427 });
            _location.Add(new Location { Identifier = "9", X = 451, Y = 510 });
            _location.Add(new Location { Identifier = "10", X = 540, Y = 501 });
            _location.Add(new Location { Identifier = "11", X = 636, Y = 598 });
            _location.Add(new Location { Identifier = "12", X = 601, Y = 453 });
            _location.Add(new Location { Identifier = "13", X = 596, Y = 401 });
            _location.Add(new Location { Identifier = "14", X = 628, Y = 331 });
            _location.Add(new Location { Identifier = "15", X = 708, Y = 298 });
            _location.Add(new Location { Identifier = "16", X = 750, Y = 259 });
            _location.Add(new Location { Identifier = "17", X = 751, Y = 162 });
            _location.Add(new Location { Identifier = "18", X = 584, Y = 219 });
            _location.Add(new Location { Identifier = "19", X = 485, Y = 194 });
            _location.Add(new Location { Identifier = "20", X = 350, Y = 358 });
            _location.Add(new Location { Identifier = "21", X = 297, Y = 262 });
            _location.Add(new Location { Identifier = "22", X = 699, Y = 462 });
            _location.Add(new Location { Identifier = "23", X = 710, Y = 390 });
            _location.Add(new Location { Identifier = "24", X = 836, Y = 353 });
            _location.Add(new Location { Identifier = "25", X = 966, Y = 427 });
            _location.Add(new Location { Identifier = "26", X = 812, Y = 514 });
            _location.Add(new Location { Identifier = "27", X = 742, Y = 610 });
            _location.Add(new Location { Identifier = "28", X = 603, Y = 655 });
            _connections.Add(new Connection(_location[0], _location[1], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[1], _location[0], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[1], _location[2], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[2], _location[1], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[2], _location[3], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[3], _location[2], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[3], _location[0], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[0], _location[3], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[3], _location[4], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[4], _location[3], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[4], _location[5], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[5], _location[4], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[5], _location[6], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[6], _location[5], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[6], _location[7], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[7], _location[6], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[7], _location[8], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[8], _location[7], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[8], _location[13], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[13], _location[8], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[13], _location[12], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[12], _location[13], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[12], _location[8], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[8], _location[12], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[12], _location[10], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[10], _location[12], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[5], _location[20], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[20], _location[5], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[9], _location[10], 2, ConnectionColour.Green));
            _connections.Add(new Connection(_location[10], _location[9], 2, ConnectionColour.Green));
            _connections.Add(new Connection(_location[10], _location[8], 2, ConnectionColour.Green));
            _connections.Add(new Connection(_location[8], _location[10], 2, ConnectionColour.Green));
            _connections.Add(new Connection(_location[8], _location[5], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[5], _location[8], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[13], _location[14], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[14], _location[13], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[14], _location[7], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[7], _location[14], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[14], _location[23], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[23], _location[14], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[23], _location[15], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[15], _location[23], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[23], _location[22], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[22], _location[23], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[9], _location[3], 3, ConnectionColour.Green));
            _connections.Add(new Connection(_location[3], _location[9], 3, ConnectionColour.Green));
            _connections.Add(new Connection(_location[9], _location[4], 3, ConnectionColour.Green));
            _connections.Add(new Connection(_location[4], _location[9], 3, ConnectionColour.Green));
            _connections.Add(new Connection(_location[20], _location[21], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[21], _location[20], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[18], _location[17], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[17], _location[18], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[18], _location[19], 3, ConnectionColour.Green));
            _connections.Add(new Connection(_location[19], _location[18], 3, ConnectionColour.Green));
            _connections.Add(new Connection(_location[17], _location[16], 3, ConnectionColour.Black));
            _connections.Add(new Connection(_location[16], _location[17], 3, ConnectionColour.Black));
            _connections.Add(new Connection(_location[19], _location[6], 5, ConnectionColour.Black));
            _connections.Add(new Connection(_location[6], _location[19], 5, ConnectionColour.Black));
            _connections.Add(new Connection(_location[15], _location[24], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[24], _location[15], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[24], _location[16], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[16], _location[24], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[15], _location[16], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[16], _location[15], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[24], _location[25], 3, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[25], _location[24], 3, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[25], _location[26], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[26], _location[25], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[26], _location[27], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[27], _location[26], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[27], _location[22], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[22], _location[27], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[22], _location[26], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[26], _location[22], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[22], _location[24], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[24], _location[22], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[22], _location[12], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[12], _location[22], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[10], _location[11], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[11], _location[10], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[11], _location[28], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[28], _location[11], 1, ConnectionColour.Orange));






            return new Map(_connections, _location);
        }

    }
}
