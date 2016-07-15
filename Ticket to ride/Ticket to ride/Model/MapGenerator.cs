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
            _location.Add(new Location { Identifier = "0", X = 245, Y = 656 });
            _location.Add(new Location { Identifier = "1", X = 236, Y = 555 });
            _location.Add(new Location { Identifier = "2", X = 362, Y = 641 });
            _location.Add(new Location { Identifier = "3", X = 360, Y = 539 });
            _location.Add(new Location { Identifier = "4", X = 365, Y = 428 });
            _location.Add(new Location { Identifier = "5", X = 415, Y = 382 });
            _location.Add(new Location { Identifier = "6", X = 451, Y = 330 });
            _location.Add(new Location { Identifier = "7", X = 347, Y = 357 });
            _location.Add(new Location { Identifier = "8", X = 290, Y = 245 });
            _location.Add(new Location { Identifier = "9", X = 424, Y = 520 });
            _location.Add(new Location { Identifier = "10", X = 513, Y = 499 });
            _location.Add(new Location { Identifier = "11", X = 460, Y = 431 });
            _location.Add(new Location { Identifier = "12", X = 517, Y = 325 });
            _location.Add(new Location { Identifier = "13", X = 515, Y = 260 });
            _location.Add(new Location { Identifier = "14", X = 509, Y = 178 });
            _location.Add(new Location { Identifier = "15", X = 588, Y = 174 });
            _location.Add(new Location { Identifier = "16", X = 518, Y = 399 });
            _location.Add(new Location { Identifier = "17", X = 599, Y = 405 });
            _location.Add(new Location { Identifier = "18", X = 624, Y = 588 });
            _location.Add(new Location { Identifier = "19", X = 591, Y = 456 });
            _location.Add(new Location { Identifier = "20", X = 593, Y = 325 });
            _location.Add(new Location { Identifier = "21", X = 706, Y = 594 });
            _location.Add(new Location { Identifier = "22", X = 678, Y = 452 });
            _location.Add(new Location { Identifier = "23", X = 703, Y = 526 });
            _location.Add(new Location { Identifier = "24", X = 659, Y = 320 });
            _location.Add(new Location { Identifier = "25", X = 670, Y = 63 });
            _location.Add(new Location { Identifier = "26", X = 756, Y = 50 });
            _location.Add(new Location { Identifier = "27", X = 786, Y = 290 });
            _location.Add(new Location { Identifier = "28", X = 786, Y = 449 });
            _location.Add(new Location { Identifier = "29", X = 969, Y = 447 });
            _location.Add(new Location { Identifier = "30", X = 864, Y = 359 });
            _location.Add(new Location { Identifier = "31", X = 788, Y = 558 });
            _connections.Add(new Connection(_location[1], _location[3], 2, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[3], _location[1], 2, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[3], _location[2], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[2], _location[3], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[2], _location[0], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[0], _location[2], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[0], _location[1], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[1], _location[0], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[9], _location[4], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[4], _location[9], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[4], _location[11], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[11], _location[4], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[11], _location[10], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[10], _location[11], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[14], _location[15], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[15], _location[14], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[24], _location[27], 2, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[27], _location[24], 2, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[12], _location[20], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[20], _location[12], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[19], _location[10], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[10], _location[19], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[3], _location[9], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[9], _location[3], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[9], _location[10], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[10], _location[9], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[11], _location[5], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[5], _location[11], 1, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[5], _location[6], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[6], _location[5], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[6], _location[12], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[12], _location[6], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[12], _location[16], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[16], _location[12], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[16], _location[11], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[11], _location[16], 1, ConnectionColour.Red));
            _connections.Add(new Connection(_location[16], _location[5], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[5], _location[16], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[22], _location[23], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[23], _location[22], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[21], _location[31], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[31], _location[21], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[31], _location[28], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[28], _location[31], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[22], _location[28], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[28], _location[22], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[22], _location[24], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[24], _location[22], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[25], _location[26], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[26], _location[25], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[5], _location[7], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[7], _location[5], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[7], _location[8], 3, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[8], _location[7], 3, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[20], _location[17], 1, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[17], _location[20], 1, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[20], _location[24], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[24], _location[20], 1, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[17], _location[19], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[19], _location[17], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[17], _location[22], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[22], _location[17], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[17], _location[16], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[16], _location[17], 1, ConnectionColour.White));
            _connections.Add(new Connection(_location[19], _location[18], 3, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[18], _location[19], 3, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[18], _location[21], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[21], _location[18], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[19], _location[23], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[23], _location[19], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[26], _location[27], 6, ConnectionColour.Black));
            _connections.Add(new Connection(_location[27], _location[26], 6, ConnectionColour.Black));
            _connections.Add(new Connection(_location[27], _location[30], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[30], _location[27], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[30], _location[29], 3, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[29], _location[30], 3, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[29], _location[28], 6, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[28], _location[29], 6, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[28], _location[30], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[30], _location[28], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[28], _location[24], 3, ConnectionColour.Black));
            _connections.Add(new Connection(_location[24], _location[28], 3, ConnectionColour.Black));
            _connections.Add(new Connection(_location[12], _location[13], 1, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[13], _location[12], 1, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[13], _location[14], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[14], _location[13], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[15], _location[25], 3, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[25], _location[15], 3, ConnectionColour.Pink));
            _connections.Add(new Connection(_location[15], _location[24], 5, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[24], _location[15], 5, ConnectionColour.Undefined));






            return new Map(_connections, _location);
        }

    }
}
