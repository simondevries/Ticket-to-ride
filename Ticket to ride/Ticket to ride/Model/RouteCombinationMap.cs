using System.Collections.Generic;

namespace Ticket_to_ride.Model
{
    /// <summary>
    /// All the possible solutions
    /// </summary>
    public class RouteCombinationMap
    {
        private readonly List<RouteSolution> _solutions;

        public RouteCombinationMap()
        {
           _solutions = new List<RouteSolution>();
        }

        public List<RouteSolution> Solutions
        {
            get { return _solutions; }
        }
    }

    /// <summary>
    /// All the connection on a map (including seperated Routes)
    /// </summary>
    public class RouteSolution
    {
        private readonly List<ConnectedRoute> _solution;

        public RouteSolution()
        {
            _solution = new List<ConnectedRoute>();
        }

        public List<ConnectedRoute> Solution
        {
            get { return _solution; }
        }
    }

    /// <summary>
    /// A connection of routes (1 or more)
    /// </summary>
    public class ConnectedRoute
    {
        private readonly List<int> _connectedRoute;

        public ConnectedRoute()
        {
            _connectedRoute = new List<int>();
        }

        public List<int> Connection
        {
            get { return _connectedRoute; }
        }
    }
}