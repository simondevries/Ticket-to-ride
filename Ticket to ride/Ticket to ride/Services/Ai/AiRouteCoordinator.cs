using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services.Ai
{
    public class AiRouteCoordinator
    {
        private readonly AiRouteGenerator _aiRouteGenerator;

        public AiRouteCoordinator()
        {
            _aiRouteGenerator = new AiRouteGenerator();
        }

        public Route GenerateRoute(Map map, int aiId, List<Location> destinations, Logger gameLog)
        {
            ShortestPathGenerator shortestPath = new ShortestPathGenerator(map.getLocations(), map.getConnections());

            //Generate A-B, A-C, A-D, B-C ...
            List<DestinationPair> destinationPairs = _aiRouteGenerator.GetDestinationPairs(destinations);

            //Add cost to each destination pair
            destinationPairs = _aiRouteGenerator.AddCostToEachDestinationPair(destinationPairs, shortestPath, destinations, aiId);
            Console.WriteLine(destinationPairs.Select(p => "" + p.StartIndex + "," + p.EndIndex + "," + p.Weight));

            //todo go through all combinations
            //todo remove identifier?
            //todo refactor to another class

            Stopwatch stopwatch = new Stopwatch();;
            List<Route> allPossibleRoutes = new List<Route>();
            RouteCombinationMap routeSolutionMap = new RouteCombinationBuilder().Build(destinations.Count);
            foreach (RouteSolution routeSolution in routeSolutionMap.Solutions)
            {
                Route finalRouteWithDuplicates = new Route("MainRoute");
                finalRouteWithDuplicates.Cost = 0;

                Route sumOfAllRoutesForARouteSolution = new Route("sumOfRoutes");

                //When there are multiple sub routes then we need to add them up (i.e. a route on the east of map + west of map)
                foreach (ConnectedRoute connectedRoute in routeSolution.Solution)
                {
                    sumOfAllRoutesForARouteSolution.CombineRoutes(AiRouteGenerator.GetRouteForThisRouteCombination(stopwatch, connectedRoute.Connection, destinationPairs, finalRouteWithDuplicates, destinations));
                }
                allPossibleRoutes.Add(sumOfAllRoutesForARouteSolution);
            }
            Console.Out.WriteLine("Processing too");
            gameLog.Log("Processing took " + stopwatch.ElapsedMilliseconds, LogType.Debug);
            //PickBest Route
            Route finalRoute = new Route("Final Route");
            int lowestRouteCost = int.MaxValue;
            foreach (Route route in allPossibleRoutes)
            {
                if (route.Cost < lowestRouteCost)
                {
                    finalRoute = route;
                    lowestRouteCost = finalRoute.Cost;
                }
            }

            return finalRoute;
        }
    }
}