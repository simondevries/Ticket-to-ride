using System;

namespace Ticket_to_ride.Model
{
    public class RouteCardDto
    {
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public bool Required { get; set; }
        public int Points { get; set; }

        public RouteCard Map()
        {
            return new RouteCard(StartLocation, EndLocation, Required, Points);
        }
    }

    public class RouteCard
    {
        readonly Location _startLocation;
        readonly Location _endLocation;
        private readonly bool _required;
        private readonly int _points;

        public RouteCard(Location start, Location end, bool required, int point)
        {
            _startLocation = start;
            _endLocation = end;
            _required = required;
            _points = point;
        }



        public Location GetStartLocation() { return _startLocation; }
        public Location GetEndLocation() { return _endLocation; }
        public bool GetRequired() { return _required; }
        public int GetPoints() { return _points; }

        public RouteCardDto Map()
        {
            return new RouteCardDto
            {
                StartLocation = _startLocation,
                EndLocation = _endLocation,
                Points = _points,
                Required = _required
            };
        }

        public override string ToString()
        {
            return String.Format("{0} to {1} for {2} points", _startLocation.Identifier, _endLocation.Identifier, _points);
        }
    }
}
