using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    public class RouteCard
    {
        readonly Location _startLocation;
        readonly Location _endLocation;

        public RouteCard(Location start, Location end)
        {
            _startLocation = start;
            _endLocation = end;
        }

        public Location GetStartLocation() { return _startLocation; }
        public Location GetEndLocation() { return _endLocation; }


    }
}
