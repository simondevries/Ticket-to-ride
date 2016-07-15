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


            int[] order = new int[destinations.Count];
            for (int i = 0; i < destinations.Count; i++)
            {
                order[i] = i;
            }

            Route finalRoute = AiRouteGenerator.GetCostForEachRouteCombination(order, destinationPairs, finalRouteWithDuplicates, destinations);
            


            return finalRoute;
        }
    }
}