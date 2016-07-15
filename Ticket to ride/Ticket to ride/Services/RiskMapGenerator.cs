using System.Collections.Generic;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    class RiskMapGenerator
    {
        readonly Map _riskMap;

        public RiskMapGenerator(Map riskMap)
        {
            _riskMap = riskMap;
        }

        public void GetConnectionWithGreatestRisk(PlayerRouteHand chosenRoute, Route choosenRoute, int playerId)
        {
            ClearRisk();

            foreach (RouteCard route in chosenRoute.GetRoutes())
            {

                foreach (Connection connection in choosenRoute.Connections)
                {
                    if (connection.Weight == 0)
                    {
                        continue;
                    }
                    int originalWeight = connection.Weight;
                    _riskMap.setWeight(connection, 9999);
                    ShortestPathGenerator shortestPath = new ShortestPathGenerator(_riskMap.getLocations(), _riskMap.getConnections());
                    Dictionary<Location, Route> _shortestLocations = shortestPath.CalculateMinCost(route.GetStartLocation(), playerId);
                    //todo Cost should be added if route overlap in multiple occasions
                    int routeCost = connection.Risk;
                    routeCost += _shortestLocations[route.GetEndLocation()].Cost;
                    SetRisk(connection, routeCost);
                    
                    _riskMap.setWeight(connection, originalWeight);
                }  
            }
        }


        private void ClearRisk()
        {
            foreach (Connection connection in _riskMap.getConnections())
            {
                connection.Risk = 0;
            }
        }


        private void SetRisk(Connection connectionToCheck, int risk)
        {
            //todo can I use index instead
            foreach (Connection connection in _riskMap.getConnections())
            {
                if (connection.A == connectionToCheck.A && connection.B == connectionToCheck.B ||
                    connection.B == connectionToCheck.A && connection.A == connectionToCheck.B)
                {
                    connection.Risk = risk;
                }
            }
        }


    }
}
