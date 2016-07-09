using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class Ai : Player
    {


        public Ai(RoutesTasks routesTasks, int id, Brush colour, Hand hand)
        {
            _task = routesTasks;
            _playerType = PlayerType.Ai;
            _id = id;
            _colour = colour;
            _hand = hand;
        }

        public void PerformTurn(Map map)
        {

            ShortestPathGenerator shortestPath = new ShortestPathGenerator(map.getLocations(), map.getConnections());

            //get list of all possible connection order
            //todo add all combination of locations

            List<Location> locations = _task.GetAllLocations();

            List<List<Location>> destinationOrders = GenerateDestinationOrders(locations);


            //0 = A - B
            //1 = A - C
            //2 = B - C
            List<int> costs = new List<int>();

            List<Route> routes = new List<Route>();


            //Foreach connection order 
            //A
            for (int i = 0; i < destinationOrders.Count; i++)
            {
                //get initial shortest between all nodes
                //todo sdv uncomment
                //    Dictionary<Location, Route> shortestLocationsAB = shortestPath.CalculateMinCost(_task.GetStartLocation(), _id);
                //  Dictionary<Location, Route> shortestLocationsBC = shortestPath.CalculateMinCost(_task.GetEndLocation(), _id);
                Dictionary<int, Route> distanceBetweenDestinations = new Dictionary<int, Route>();
                //                distanceBetweenDestinations[0] = shortestLocationsAB[_task.GetEndLocation()];
                //                distanceBetweenDestinations[1] = shortestLocationsAB[_task.GetThirdLocation()];
                //                distanceBetweenDestinations[2] = shortestLocationsBC[_task.GetThirdLocation()];

                //B
                //Reset weight
                //Set the weight to 0 of all the selected routes

                //Check if there is a fast way for that distance between destinations
                //If there is then set the distance BetweenDistinations

                for (int j = 0; j < destinationOrders[i].Count - 1; j++)
                {
                    foreach (Connection connection in map.getConnections())
                    {
                        connection.WeightForComputation = connection.Weight;
                    }

                    foreach (Route route in distanceBetweenDestinations.Values)
                    {
                        foreach (Connection connection in route.Connections)
                        {
                            connection.Weight = 0;
                        }
                    }

                    Dictionary<Location, Route> routeOne = shortestPath.CalculateMinCost(destinationOrders[i][j], _id);
                    distanceBetweenDestinations.Add(j, routeOne[destinationOrders[i][j + 1]]);


                    foreach (Connection connection in map.getConnections())
                    {
                        connection.Weight = connection.WeightForComputation;
                    }
                }
                costs.Add(distanceBetweenDestinations[0].Cost + distanceBetweenDestinations[1].Cost);


                List<Connection> routeToAdd = new List<Connection>();

                foreach (Route destinationRoute in distanceBetweenDestinations.Values)
                {
                    foreach (var connection in destinationRoute.Connections)
                    {
                        if (routeToAdd.Count(conn => conn == connection) == 0)
                        {
                            routeToAdd.Add(connection);
                        }
                    }
                }
                routes.Add(new Route("asd") { Connections = routeToAdd });

            }



            //Foreach connection 
            //Find shortest
            //If found shorter
            // Update all other connectors (see hashmap)



            //Get shortest of all connections, set as shortestpath
            //Dictionary<Location, Route> shortestLocations = shortestPath.CalculateMinCost(_task.GetStartLocation(), _id);
            Route chosenRoute = routes.OrderBy(route => route.Connections.Count).First();

            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            //todo sdv uncommment !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //  riskMapGenerator.getConnectionWithGreatestRisk(chosenRoute, _task, _id);

            //does this update the risk here ?
            Connection trainPlacement = TrainPlacementDecider.PlaceTrain(map);
            TrianPlacer.PlaceTrain(trainPlacement, map, this);

        }

        private List<List<Location>> GenerateDestinationOrders(List<Location> inputLocations)
        {
            Console.Write("All locations: ");
            foreach (var loc in inputLocations)
            {
                Console.Write("" + loc.Identifier);
            }
            Console.WriteLine();
            List<Location> alreadyProcessed = new List<Location>();
            List<List<Location>> desinationOrders = new List<List<Location>>();



            for (int i = 0; i < inputLocations.Count; i++)
            {
                List<Location> locations = inputLocations.Select(item => (Location)item).ToList();
                Swap(locations, i, 0);
                PrintAlreadyProcessed(locations[i], alreadyProcessed);
                List<Location> allLocationsExceptFirst = locations.GetRange(1, locations.Count - 1);
                List<List<Location>> destinationOrder = GetDestinationOrder(allLocationsExceptFirst, alreadyProcessed, 0);
                foreach (List<Location> list in destinationOrder)
                {
                    list.Insert(0, locations[0]);
                    desinationOrders.Add(list);
                }


                alreadyProcessed.Add(locations[0]);
            }

            foreach (List<Location> desinationOrder in desinationOrders)
            {
                Console.WriteLine();
                foreach (var location in desinationOrder)
                {
                    Console.Write(location.Identifier);
                }
            }

            return desinationOrders;
        }

        private static void PrintAlreadyProcessed(Location location, List<Location> alreadyProcessed)
        {
            Console.WriteLine("Processing for " + location.Identifier);
            foreach (Location alreadyProcessedLocation in alreadyProcessed)
            {
                Console.WriteLine("" + alreadyProcessedLocation.Identifier);
            }
        }

        private static List<List<Location>> GetDestinationOrder(List<Location> inputLocations, List<Location> alreadyProcessed, int tabLevel)
        {
            Console.WriteLine();
            for (int i = 0; i < tabLevel; i++)
            {
                Console.Write('\t');
            }
            foreach (Location location in inputLocations)
            {
                Console.Write(location.Identifier);
            }

            List<List<Location>> allCombinations = new List<List<Location>>();

            if (inputLocations.Count == 2)
            {
                Console.Write("base case: ");


                if (alreadyProcessed.Contains(inputLocations[1]) == false)
                {
                    Console.Write("adding locations in order 0,1 ");
                    allCombinations.Add(new List<Location> { inputLocations[0], inputLocations[1] });
                }
                 if ((alreadyProcessed.Contains(inputLocations[0]) == false))
                {
                    Console.Write("adding locations in order 1,0 ");
                    allCombinations.Add(new List<Location> { inputLocations[1], inputLocations[0] });

                }
                return allCombinations;
            }

            Console.Write("Not base case");

            for (int i = 0; i < inputLocations.Count; i++)
            {
                List<Location> locations =  inputLocations.Select(item => (Location)item).ToList();;
                Swap(locations, 0, i);
                
                Location currentLocation = locations[0];

                Console.Write(", removing location 0 (" + currentLocation.Identifier + ")");
                
                List<List<Location>> subLocation = new List<List<Location>>();

                Console.Write("identifier " + currentLocation.Identifier + " is now running for remaining locations");

                foreach (List<Location> result in GetDestinationOrder(locations.GetRange(1, locations.Count -1), alreadyProcessed, tabLevel + 1))
                {
                    Console.Write("identifier " + currentLocation.Identifier + " is adding ");
                    foreach (Location location in result)
                    {
                        Console.Write(location.Identifier);
                    }
                    subLocation.Add(result);
                }


                foreach (List<Location> list in subLocation)
                {
                    Console.Write("identifier " + currentLocation.Identifier + " is inserting itself into all combinations");
                    list.Insert(0, currentLocation);
                    allCombinations.Add(list);
                }

            }

            return allCombinations;
        }

        public static void Swap(List<Location> list, int indexA, int indexB)
        {
            Location tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
