using System;

namespace Ticket_to_ride.Model
{
    public class RouteCard
    {
        readonly Location _startLocation;
        readonly Location _endLocation;
        private readonly bool _required;

        public RouteCard(Location start, Location end, bool required)
        {
            _startLocation = start;
            _endLocation = end;
            _required = required;
        }

        public Location GetStartLocation() { return _startLocation; }
        public Location GetEndLocation() { return _endLocation; }
        public bool GetRequired() { return _required; }

        public override string ToString()
        {
            return String.Format("{0} to {1}", _startLocation.Identifier, _endLocation.Identifier);
        }
    }
}
