using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
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

        public int GetPoints()
        {
            int point = 0;

            foreach (Connection connection in _connections)
            {
                point += PointMapper.GetPointsForRouteWeight(connection.Weight);
            }
            return point;
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

        public void CombineRoutes(Route newRoute)
        {
            if (!newRoute.Connections.Any())
            {
                return;
            }
            if (!Connections.Any())
            {
                Connections = newRoute.Connections;
                Cost = newRoute.Cost;
                return;
            }

            List<Connection> newConnections = new List<Connection>();
//            Connections.AddRange(newRoute.Connections);
//            _cost += newRoute.Cost
            //todo worry about dup connections- this will cause it to not favour dup locations
            //todo hash table


            foreach (Connection connection in Connections)
            {
                foreach (Connection newConnection in newRoute.Connections)
                {
                    if (!connection.HasSameStartAndEnd(newConnection))
                    {
                        newConnections.Add(newConnection);
                        Cost += newConnection.Weight;
                    }
                }
            }
            Connections = newConnections;
        }
    }
}
