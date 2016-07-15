using System.Collections.Generic;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    public class Route
    {
        int _cost;
        List<Connection> _connections;
        string _identifier;
        //todo make prop
        public List<DestinationPair> startAndEnd;

        public Route(string _identifier)
        {
            //why intmax?
            _cost = int.MaxValue;
            _connections = new List<Connection>();
            this._identifier = _identifier;
            startAndEnd = new List<DestinationPair>();
        }


        public void AddRoute(Route route)
        {
            _connections.AddRange(route.Connections);
        }


        public void AddConnections(List<Connection> connections)
        {
            _connections.AddRange(connections);
        }

        public List<Connection> Connections
        {
            get { return _connections; }
            set { _connections = value; }
        }
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }


     

        public override string ToString()
        {
            string output = "";
            foreach (Connection connection in Connections)
            {
                output += connection.A + "->" + connection.B + ", ";
            }
            return output;
        }


        public void AddConnection(Connection connection)
        {
            _connections.Add(connection);
        }
    }
}
