using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class RouteExistsBetweenLocationsValidator
    {
        public bool DoesRouteExist(Location startLocation, Location endLocation, Map map, Player player)
        {
            Stack<Connection> routeStack = new Stack<Connection>();
            List<Connection> visitedLocations = new List<Connection>();

            AddConnectionsToRouteStack(startLocation, routeStack, player, map);

            while (routeStack.Any())
            {
                Connection currentConnection = routeStack.Pop();
                
                if (visitedLocations.Contains(currentConnection) == false)
                {
                    if (currentConnection.A == endLocation || currentConnection.B == endLocation)
                    {
                        return true;
                    }

                    
                    AddConnectionsToRouteStack(currentConnection.A, routeStack, player, map);
                    AddConnectionsToRouteStack(currentConnection.B, routeStack, player, map);
                        
                    visitedLocations.Add(currentConnection);
                }


            }
            return false;
        }

        private static void AddConnectionsToRouteStack(Location startLocation, Stack<Connection> routeStack, Player player, Map map)
        {
            //Add initial connections
            foreach (string connectionIdentity in startLocation.AssociatedConnections)
            {
                Connection connection = map.GetConnectionByIdentity(connectionIdentity);

                if (connection.Owner == player)
                {
                    routeStack.Push(connection);
                }
            }
        }
    }
}