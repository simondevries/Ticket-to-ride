using System.Collections.Generic;

namespace Ticket_to_ride.Model
{
    public class Location
    {
        public static Location Empty()
        {
            Location location = new Location();
            location.x = -1;
            location.y = -1;
            location._identifier = "-1";

            return location;
        }

        int x, y;
        string _identifier;
        public Location()
        {
            AssociatedConnections = new List<string>();
        }

        public List<string> AssociatedConnections
        {
            get;
            set;
        }

        public void AddToAssociatedConnections(string connectionIdentity)
        {
            AssociatedConnections.Add(connectionIdentity);
        }

        public string Identifier
        {
            get { return _identifier; }
            set { this._identifier = value; }
        }
        public override string ToString()
        {
            return _identifier;
        }

        public int Width
        {
            get { return 25; }

        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public LocationDto Map()
        {
            return new LocationDto { Identifier = Identifier, X = x, Y = y };
        }
    }
}