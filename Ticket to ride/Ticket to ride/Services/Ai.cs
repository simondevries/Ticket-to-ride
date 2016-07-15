using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class Ai : Player
    {


        public Ai(PlayerRouteHand playerRouteHand, int id, Brush colour, TrainDeck trainDeck)
            : base(trainDeck)
        {
            PlayerRouteHand = playerRouteHand;
            _playerType = PlayerType.Ai;
            _id = id;
            _colour = colour;
        }

        public void PerformTurn(Map map)
        {
            Route choosenRoute = GenerateRoute(map);
            Console.WriteLine(choosenRoute.ToString());
            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            //Pass in with the correct order

            riskMapGenerator.getConnectionWithGreatestRisk(choosenRoute, _id);
            Connection trainPlacement = TrainPlacementDecider.PlaceTrain(map);
            bool placeTrain = TrianPlacer.PlaceTrain(trainPlacement, map, this);

            if (placeTrain == false)
            {
                Console.WriteLine("Computer failed to place train");
            }
        }

        private Route GenerateRoute(Map map)
        {
            ShortestPathGenerator shortestPath = new ShortestPathGenerator(map.getLocations(), map.getConnections());

            List<Location> destinations = PlayerRouteHand.GetAllLocations();
            //Generate A-B, A-C, A-D, B-C ...
            List<DestinationPair> destinationPairs = GetDestinationPairs(destinations);

            //Add cost to each destination pair
            destinationPairs = AddCostToEachDestinationPair(destinationPairs, shortestPath, destinations);
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
            for (int i = 0; i < order.Length - 1; i++)
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
//            IEnumerable<Connection> connections = finalRouteWithDuplicates.Connections.Distinct();
            //            finalRoute.AddConnections(connections.ToList());
            Route finalRoute = new Route("");
            finalRoute.startAndEnd = finalRouteWithDuplicates.startAndEnd;
            foreach (Connection connection in finalRouteWithDuplicates.Connections)
            {
                bool foundElsewhere = false;
                foreach (Connection connectionCompare in finalRouteWithDuplicates.Connections)
                {
                    if((connection.A == connectionCompare.A && connection.B==connectionCompare.B ||
                        connection.B == connectionCompare.A && connection.A==connectionCompare.B) &&
                        connection != connectionCompare)
                    {
                        foundElsewhere = true;
                    }
                }
                if (!foundElsewhere || !finalRoute.Connections.Contains(connection))
                {
                    finalRoute.AddConnection(connection);
                }
            }

            return finalRoute;
        }

        private List<DestinationPair> AddCostToEachDestinationPair(List<DestinationPair> destinationPairs, ShortestPathGenerator shortestPath, List<Location> destinations)
        {
            //todo can i reduce complexity since this is run twice for final Destination Pair (i.e 0->4 and 4->0)
            foreach (DestinationPair destinationPair in destinationPairs)
            {
                //Get shortest path from this to all other
                Dictionary<Location, Route> allRoutes = shortestPath.CalculateMinCost(destinations[destinationPair.StartIndex],
                    _id);

                //Get all pairs that link to this Destination pair start
                IEnumerable<DestinationPair> destinationPairsWithThisStartLocation =
                    destinationPairs.Where(pair => pair.HasStartOrEnd(destinationPair.StartIndex) && !pair.HasWeight);

                //Update the pair with the route and cost
                foreach (DestinationPair pair in destinationPairsWithThisStartLocation)
                {

                    Location location = destinations[pair.GetOppositeEnd(pair.StartIndex)];
                    pair.Weight = allRoutes[location].Cost;
                    pair.Route.AddConnections(allRoutes[location].Connections);
                }
            }
            return destinationPairs;
        }

        private List<DestinationPair> GetDestinationPairs(List<Location> destinations)
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
    }

    public class DestinationPair
    {
        //todo merge
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        private readonly int _endIndex;
        private readonly int _startIndex;
        private int _weight;
        private Route _route;

        public DestinationPair(int startIndex, int endIndex)
        {
            _startIndex = startIndex;
            _endIndex = endIndex;

            _route = new Route("");
        }


        public override string ToString()
        {
            return _startIndex + " -> " + _endIndex;
        }

        public override bool Equals(object o)
        {
            DestinationPair destinationPair = (DestinationPair)o;
            return _endIndex == destinationPair._endIndex && _startIndex == destinationPair._startIndex;
        }

        public bool HasStartAndEnd(int startId, int endId)
        {
            return _startIndex == startId && _endIndex == endId;
        }

        public bool HasStartOrEnd(int locationIndex)
        {
            return _startIndex == locationIndex || _endIndex == locationIndex;
        }

        public bool HasLocationId(int locationId)
        {
            return _startIndex == locationId || _endIndex == locationId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_endIndex * 397) ^ _startIndex;
            }
        }

        public bool HasWeight
        {
            get { return Weight != 0; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int EndIndex { get { return _endIndex; } }
        public int StartIndex { get { return _startIndex; } }
        public Route Route { get { return _route; }
            set { _route = value;  } }

        public int GetOppositeEnd(int index)
        {
            return _startIndex == index ? _endIndex : _startIndex;
        }
    }
}
