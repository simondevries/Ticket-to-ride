using System.Collections.Generic;

namespace Ticket_to_ride.Model
{
    public class Location
    {

        int x, y;
        string _identifier;
        public Location()
        {
            AssociatedConnections = new List<Connection>();
        }

        public List<Connection> AssociatedConnections
        {
            get;
            set;
        }

        public void AddToAssociatedConnections(Connection connection)
        {
            AssociatedConnections.Add(connection);
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

    }
}
