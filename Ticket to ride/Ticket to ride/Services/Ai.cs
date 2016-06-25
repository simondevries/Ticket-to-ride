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
//            //todo add all combination of locations
//            List<List<Location>> destinationOrders = new List<List<Location>>
//            {
//                new List<Location> {_task.GetStartLocation(), _task.GetEndLocation(), _task.GetThirdLocation()},
//                new List<Location> {_task.GetStartLocation(), _task.GetThirdLocation(), _task.GetEndLocation()},
//            };
//
//            //0 = A - B
//            //1 = A - C
//            //2 = B - C
//            List<int> costs = new List<int>();
//
//            List<Route> routes = new List<Route>();
//
//
//            //Foreach connection order 
//            //A
//            for (int i = 0; i < destinationOrders.Count; i++)
//            {
//                //get initial shortest between all nodes
//                Dictionary<Location, Route> shortestLocationsAB = shortestPath.CalculateMinCost(_task.GetStartLocation(), _id);
//                Dictionary<Location, Route> shortestLocationsBC = shortestPath.CalculateMinCost(_task.GetEndLocation(), _id);
//                Dictionary<int, Route> distanceBetweenDestinations = new Dictionary<int, Route>();
////                distanceBetweenDestinations[0] = shortestLocationsAB[_task.GetEndLocation()];
////                distanceBetweenDestinations[1] = shortestLocationsAB[_task.GetThirdLocation()];
////                distanceBetweenDestinations[2] = shortestLocationsBC[_task.GetThirdLocation()];
//
//                //B
//                //Reset weight
//                //Set the weight to 0 of all the selected routes
//
//                //Check if there is a fast way for that distance between destinations
//                //If there is then set the distance BetweenDistinations
//
//                for (int j = 0; j < destinationOrders[i].Count - 1; j++)
//                {
//                    foreach (Connection connection in map.getConnections())
//                    {
//                        connection.WeightForComputation = connection.Weight;
//                    }
//
//                    foreach (Route route in distanceBetweenDestinations.Values)
//                    {
//                        foreach (Connection connection in route.Connections)
//                        {
//                            connection.Weight = 0;
//                        }
//                    }
//
//                    Dictionary<Location, Route> routeOne = shortestPath.CalculateMinCost(destinationOrders[i][j], _id);
//                    distanceBetweenDestinations.Add(j, routeOne[destinationOrders[i][j + 1]]);
//                    
//
//                    foreach (Connection connection in map.getConnections())
//                    {
//                        connection.Weight = connection.WeightForComputation;
//                    }
//                }
//                costs.Add(distanceBetweenDestinations[0].Cost + distanceBetweenDestinations[1].Cost);
//                
//
//                List<Connection> routeToAdd = new List<Connection>();
//
//                foreach (Route destinationRoute in distanceBetweenDestinations.Values)
//                {
//                    foreach (var connection in destinationRoute.Connections)
//                    {
//                        if (routeToAdd.Count(conn => conn == connection) == 0)
//                        {
//                            routeToAdd.Add(connection);
//                        }
//                    }
//                }
//                routes.Add(new Route("asd"){Connections = routeToAdd});
//
//            }
//
//
//
//            //Foreach connection 
//            //Find shortest
//            //If found shorter
//            // Update all other connectors (see hashmap)
//
//            
//
//            //Get shortest of all connections, set as shortestpath
//            //Dictionary<Location, Route> shortestLocations = shortestPath.CalculateMinCost(_task.GetStartLocation(), _id);
//            Route chosenRoute = routes.OrderBy(route => route.Connections.Count).First();
//
//            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
//            riskMapGenerator.getConnectionWithGreatestRisk(chosenRoute, _task, _id);
//
//            //does this update the risk here ?
//            Connection trainPlacement = TrainPlacementDecider.PlaceTrain(map);
//            TrianPlacer.PlaceTrain(trainPlacement, map, this);

        }
    }
}
