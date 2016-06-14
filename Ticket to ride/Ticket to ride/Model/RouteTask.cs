using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    public class RouteTask
    {
        Location _startLocation;
        Location _endLocation;

        public RouteTask(Location start, Location end)
        {
            _startLocation = start;
            _endLocation = end;
        }

        public Location getStartLocation() { return _startLocation; }
        public Location getEndLocation() { return _endLocation; }

    }
}
