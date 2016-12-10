using System.Collections.Generic;
using System.Linq;

namespace Ticket_to_ride.Model
{

    //this dto is used for Connection -> location
    public class LocationDto
    {
        public string Identifier { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Location Map(List<Location> locations)
        {
            return locations.First(loc => loc.Identifier == Identifier);
        }
    }
}