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

            AddConnectionsToRouteStack(startLocation, routeStack, player);

            while (routeStack.Any())
            {
                Connection currentConnection = routeStack.Pop();
                
                if (visitedLocations.Contains(currentConnection) == false)
                {
                    if (currentConnection.A == endLocation || currentConnection.B == endLocation)
                    {
                        return true;
                    }

                    
                    AddConnectionsToRouteStack(currentConnection.A, routeStack, player);
                    AddConnectionsToRouteStack(currentConnection.B, routeStack, player);
                        
                    visitedLocations.Add(currentConnection);
                }


            }
            return false;
        }

        private static void AddConnectionsToRouteStack(Location startLocation, Stack<Connection> routeStack, Player player)
        {
            //Add initial connections
            foreach (var connection in startLocation.AssociatedConnections)
            {
                if (connection.Owner == player)
                {
                    routeStack.Push(connection);
                }
            }
        }
    }
}