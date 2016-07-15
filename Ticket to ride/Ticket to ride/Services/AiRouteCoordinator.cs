using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class AiRouteCoordinator
    {
        private AiRouteGenerator _aiRouteGenerator;
        private Ai _ai;

        public AiRouteCoordinator(Ai ai)
        {
            _ai = ai;
            _aiRouteGenerator = new AiRouteGenerator();
        }

        public Route GenerateRoute(Map map)
        {
            ShortestPathGenerator shortestPath = new ShortestPathGenerator(map.getLocations(), map.getConnections());

            List<Location> destinations = _ai.PlayerRouteHand.GetAllLocations();
            //Generate A-B, A-C, A-D, B-C ...
            List<DestinationPair> destinationPairs = _aiRouteGenerator.GetDestinationPairs(destinations);

            //Add cost to each destination pair
            destinationPairs = _aiRouteGenerator.AddCostToEachDestinationPair(destinationPairs, shortestPath, destinations, _ai._id);
            Console.WriteLine(destinationPairs.Select(p => "" + p.StartIndex + "," + p.EndIndex + "," + p.Weight));

            //todo go through all combinations
            //todo remove identifier?
            Route finalRouteWithDuplicates = new Route("MainRoute");
            finalRouteWithDuplicates.Cost = 0;

            List<Route> allPossibleRoutes = new List<Route>();
            RouteCombinationMap routeSolutionMap = new RouteCombinationBuilder().Build(destinations.Count);
            foreach (RouteSolution routeSolution in routeSolutionMap.Solutions)
            {
                Route sumOfAllRoutesForARouteSolution = new Route("sumOfRoutes");
                //When there are multiple sub routes then we need to add them up (i.e. a route on the east of map + west of map)
                foreach (ConnectedRoute connectedRoute in routeSolution.Solution)
                {
                    sumOfAllRoutesForARouteSolution.CombineRoutes(AiRouteGenerator.GetRouteForThisRouteCombination(connectedRoute.Connection, destinationPairs, finalRouteWithDuplicates, destinations));
                }
                allPossibleRoutes.Add(sumOfAllRoutesForARouteSolution);
            }
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