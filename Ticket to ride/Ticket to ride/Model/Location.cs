using System.Collections.Generic;
using System.Linq;

namespace Ticket_to_ride.Model
{
    //this dto is used for Connection -> location
    public class LocationDto
    {
        public string Identifier { get; set; }

        public Location Map(List<Location> locations)
        {
            return locations.First(loc => loc.Identifier == Identifier);
        }
    }

    public class Location
    {

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
            return new LocationDto {Identifier = Identifier};
        }
    }
}
