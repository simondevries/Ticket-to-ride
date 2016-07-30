using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services.Ai
{
    public class AiRouteGenerator
    {
        public static Route GetRouteForThisRouteCombination(Stopwatch stopwatch, List<int> order, List<DestinationPair> destinationPairs, Route finalRouteWithDuplicates,
            List<Location> destinations)
        {
            for (int i = 0; i < order.Count - 1; i++)
            {
                int startIndex = order[i];
                int endIndex = order[i + 1];

                DestinationPair associateDestinationPair =
                    destinationPairs.FirstOrDefault(pair => pair.HasStartAndEnd(startIndex, endIndex));
                finalRouteWithDuplicates.AddRoute(associateDestinationPair.Route);

                //todo clean
                associateDestinationPair.StartLocation = destinations[associateDestinationPair.StartIndex];
                associateDestinationPair.EndLocation = destinations[associateDestinationPair.EndIndex];

                finalRouteWithDuplicates.startAndEnd.Add(associateDestinationPair);
            }

            //remove dupes
            stopwatch.Start();
            Dictionary<string, Connection> processedRoutes = new Dictionary<string, Connection>();
            foreach (Connection connection in finalRouteWithDuplicates.Connections)
            {
                if (!processedRoutes.ContainsKey(connection.A + "" + connection.B) &&
                    !processedRoutes.ContainsKey(connection.B + "" + connection.A))
                {
                    processedRoutes.Add(connection.A + "" + connection.B, connection);
                }
            }

            Route finalRoute = new Route("AiRoute");
            finalRoute.startAndEnd = finalRouteWithDuplicates.startAndEnd;
            //cost?
            foreach (KeyValuePair<string, Connection> processedRoute in processedRoutes)
            {
                finalRoute.Connections.Add(processedRoute.Value);
            }
            stopwatch.Stop();

            AddCostToFinalRoute(finalRoute);

            return finalRoute;
        }

        private static void AddCostToFinalRoute(Route finalRoute)
        {
            finalRoute.Cost = 0;
            foreach (Connection connection in finalRoute.Connections)
            {
                finalRoute.Cost += connection.Weight;
            }
        }


        public List<DestinationPair> GetDestinationPairs(List<Location> destinations)
        {
            List<DestinationPair> destinationPairs = new List<DestinationPair>();
            for (int i = 0; i < destinations.Count; i++)
            {
                for (int j = 0; j < destinations.Count; j++)
                {
                    if (i != j)
                    {
                        destinationPairs.Add(new DestinationPair(i, j));
                    }
                }
            }
            return destinationPairs;
        }


        public List<DestinationPair> AddCostToEachDestinationPair(List<DestinationPair> destinationPairs, ShortestPathGenerator shortestPath, List<Location> destinations, int id)
        {
            //todo can i reduce complexity since this is run twice for final Destination Pair (i.e 0->4 and 4->0)
            foreach (DestinationPair destinationPair in destinationPairs)
            {
                //Get shortest path from this to all other
                Dictionary<Location, Route> allRoutes = shortestPath.CalculateMinCost(destinations[destinationPair.StartIndex],
                    id);

                //Get all pairs that link to this Destination pair start
                IEnumerable<DestinationPair> destinationPairsWithThisStartLocation =
                    destinationPairs.Where(pair => pair.HasStartOrEnd(destinationPair.StartIndex) && !pair.HasWeight);
               
                //Update the pair with the route and cost
                foreach (DestinationPair pair in destinationPairsWithThisStartLocation)
                {

                    Location location = destinations[pair.GetOppositeEnd(pair.StartIndex)];
                    pair.Weight = allRoutes[location].Cost;
                    pair.Route.AddConnections(allRoutes[location].Connections);

                    SumUpAllRouteCosts(pair, allRoutes, location);
                }
            }
            return destinationPairs;
        }

        private static void SumUpAllRouteCosts(DestinationPair pair, Dictionary<Location, Route> allRoutes, Location location)
        {
            pair.Route.Cost = 0;
            foreach (Connection connection in allRoutes[location].Connections)
            {
                pair.Route.Cost += connection.Weight;
            }
        }
    }
}