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
            _location.Add(new Location { Identifier = "Edinburgh", X = 289, Y = 45 });
            _location.Add(new Location { Identifier = "London", X = 303, Y = 187 });
            _location.Add(new Location { Identifier = "Amsterdam", X = 423, Y = 178 });
            _location.Add(new Location { Identifier = "Dieppe", X = 273, Y = 273 });
            _location.Add(new Location { Identifier = "Brest", X = 172, Y = 284 });
            _location.Add(new Location { Identifier = "Paris", X = 308, Y = 337 });
            _location.Add(new Location { Identifier = "Bruxelles", X = 388, Y = 257 });
            _location.Add(new Location { Identifier = "Essen", X = 548, Y = 172 });
            _location.Add(new Location { Identifier = "Frankfurt", X = 467, Y = 298 });
            _location.Add(new Location { Identifier = "Kobenhavn", X = 617, Y = 36 });
            _location.Add(new Location { Identifier = "Munichen", X = 575, Y = 332 });
            _location.Add(new Location { Identifier = "Zurich", X = 444, Y = 380 });
            _location.Add(new Location { Identifier = "Lisbon", X = 18, Y = 556 });
            _location.Add(new Location { Identifier = "Cadiz", X = 175, Y = 639 });
            _location.Add(new Location { Identifier = "Madrid", X = 139, Y = 497 });
            _location.Add(new Location { Identifier = "Barcelona", X = 261, Y = 549 });
            _location.Add(new Location { Identifier = "Pamplona", X = 239, Y = 445 });
            _location.Add(new Location { Identifier = "Marseille", X = 398, Y = 469 });
            _location.Add(new Location { Identifier = "Roma", X = 575, Y = 502 });
            _location.Add(new Location { Identifier = "Palermo", X = 628, Y = 651 });
            _location.Add(new Location { Identifier = "Birindisi", X = 655, Y = 575 });
            _location.Add(new Location { Identifier = "Vinezia", X = 588, Y = 423 });
            _location.Add(new Location { Identifier = "Berlin", X = 656, Y = 197 });
            _location.Add(new Location { Identifier = "Kobenhaven", X = 520, Y = 64 });
            _location.Add(new Location { Identifier = "Stockholm", X = 634, Y = 16 });
            _location.Add(new Location { Identifier = "Danzig", X = 770, Y = 96 });
            _location.Add(new Location { Identifier = "Warzawa", X = 836, Y = 177 });
            _location.Add(new Location { Identifier = "Riga", X = 879, Y = 26 });
            _location.Add(new Location { Identifier = "Wilno", X = 961, Y = 172 });
            _location.Add(new Location { Identifier = "Wien", X = 700, Y = 300 });
            _location.Add(new Location { Identifier = "Budapest", X = 769, Y = 354 });
            _location.Add(new Location { Identifier = "Zagrab", X = 681, Y = 399 });
            _location.Add(new Location { Identifier = "Sarajevo", X = 718, Y = 547 });
            _location.Add(new Location { Identifier = "Athina", X = 837, Y = 608 });
            _location.Add(new Location { Identifier = "Smyrna", X = 918, Y = 650 });
            _location.Add(new Location { Identifier = "Sofia", X = 799, Y = 483 });
            _location.Add(new Location { Identifier = "Constantinple", X = 967, Y = 544 });
            _location.Add(new Location { Identifier = "Angora", X = 1031, Y = 620 });
            _location.Add(new Location { Identifier = "Bucuresti", X = 925, Y = 430 });
            _location.Add(new Location { Identifier = "Sevastopol", X = 1082, Y = 389 });
            _location.Add(new Location { Identifier = "Sochi", X = 1201, Y = 391 });
            _location.Add(new Location { Identifier = "Erzurum", X = 1142, Y = 523 });
            _location.Add(new Location { Identifier = "Rostov", X = 1193, Y = 281 });
            _location.Add(new Location { Identifier = "Kyiv", X = 973, Y = 280 });
            _location.Add(new Location { Identifier = "Kharkov", X = 1128, Y = 229 });
            _location.Add(new Location { Identifier = "Moskva", X = 1197, Y = 115 });
            _location.Add(new Location { Identifier = "Smolensk", X = 1088, Y = 164 });
            _location.Add(new Location { Identifier = "Petrogran", X = 1035, Y = 11 });
            _connections.Add(new Connection(_location[1], _location[0], 4, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[1], _location[2], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[1], _location[3], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[2], _location[7], 3, ConnectionColour.White));
            _connections.Add(new Connection(_location[8], _location[7], 2, ConnectionColour.Green));
            _connections.Add(new Connection(_location[8], _location[6], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[5], _location[6], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[5], _location[3], 1, ConnectionColour.Green));
            _connections.Add(new Connection(_location[4], _location[3], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[4], _location[3], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[4], _location[5], 3, ConnectionColour.White));
            _connections.Add(new Connection(_location[3], _location[6], 2, ConnectionColour.Green));
            _connections.Add(new Connection(_location[2], _location[6], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[8], _location[10], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[11], _location[10], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[11], _location[5], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[8], _location[5], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[13], _location[12], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[14], _location[12], 3, ConnectionColour.White));
            _connections.Add(new Connection(_location[14], _location[13], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[14], _location[15], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[16], _location[15], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[16], _location[14], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[16], _location[4], 4, ConnectionColour.Green));
            _connections.Add(new Connection(_location[16], _location[5], 4, ConnectionColour.Black));
            _connections.Add(new Connection(_location[16], _location[17], 4, ConnectionColour.White));
            _connections.Add(new Connection(_location[15], _location[17], 4, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[11], _location[17], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[18], _location[17], 4, ConnectionColour.Green));
            _connections.Add(new Connection(_location[18], _location[19], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[18], _location[20], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[18], _location[21], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[11], _location[21], 2, ConnectionColour.White));
            _connections.Add(new Connection(_location[10], _location[21], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[22], _location[7], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[23], _location[7], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[23], _location[24], 3, ConnectionColour.White));
            _connections.Add(new Connection(_location[25], _location[22], 3, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[25], _location[26], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[22], _location[26], 4, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[28], _location[27], 4, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[28], _location[26], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[27], _location[25], 3, ConnectionColour.Black));
            _connections.Add(new Connection(_location[22], _location[8], 3, ConnectionColour.Black));
            _connections.Add(new Connection(_location[22], _location[29], 3, ConnectionColour.Green));
            _connections.Add(new Connection(_location[10], _location[29], 3, ConnectionColour.White));
            _connections.Add(new Connection(_location[30], _location[29], 1, ConnectionColour.Black));
            _connections.Add(new Connection(_location[30], _location[31], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[21], _location[31], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[29], _location[31], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[32], _location[31], 3, ConnectionColour.Red));
            _connections.Add(new Connection(_location[32], _location[33], 4, ConnectionColour.Green));
            _connections.Add(new Connection(_location[20], _location[33], 4, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[34], _location[33], 4, ConnectionColour.White));
            _connections.Add(new Connection(_location[34], _location[19], 6, ConnectionColour.Black));
            _connections.Add(new Connection(_location[35], _location[32], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[35], _location[36], 3, ConnectionColour.White));
            _connections.Add(new Connection(_location[34], _location[36], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[34], _location[37], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[36], _location[37], 2, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[36], _location[38], 3, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[35], _location[38], 3, ConnectionColour.Black));
            _connections.Add(new Connection(_location[30], _location[38], 4, ConnectionColour.Red));
            _connections.Add(new Connection(_location[39], _location[38], 4, ConnectionColour.White));
            _connections.Add(new Connection(_location[39], _location[36], 4, ConnectionColour.Green));
            _connections.Add(new Connection(_location[39], _location[40], 2, ConnectionColour.Red));
            _connections.Add(new Connection(_location[41], _location[40], 2, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[41], _location[37], 2, ConnectionColour.Green));
            _connections.Add(new Connection(_location[41], _location[39], 3, ConnectionColour.White));
            _connections.Add(new Connection(_location[42], _location[40], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[42], _location[39], 4, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[43], _location[30], 6, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[26], _location[29], 4, ConnectionColour.White));
            _connections.Add(new Connection(_location[43], _location[26], 4, ConnectionColour.Black));
            _connections.Add(new Connection(_location[43], _location[38], 4, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[43], _location[44], 4, ConnectionColour.Orange));
            _connections.Add(new Connection(_location[42], _location[44], 2, ConnectionColour.Green));
            _connections.Add(new Connection(_location[45], _location[44], 4, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[45], _location[46], 2, ConnectionColour.Black));
            _connections.Add(new Connection(_location[43], _location[46], 3, ConnectionColour.White));
            _connections.Add(new Connection(_location[28], _location[46], 3, ConnectionColour.Green));
            _connections.Add(new Connection(_location[47], _location[27], 4, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[47], _location[45], 4, ConnectionColour.Red));
            _connections.Add(new Connection(_location[47], _location[24], 8, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[47], _location[28], 8, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[5], _location[17], 4, ConnectionColour.Undefined));
            _connections.Add(new Connection(_location[35], _location[33], 3, ConnectionColour.Red));






            return new Map(_connections, _location);
        }

    }
}
