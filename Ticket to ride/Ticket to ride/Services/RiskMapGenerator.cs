using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    class RiskMapGenerator
    {
        Map _riskMap;

        public RiskMapGenerator(Map riskMap)
        {
            _riskMap = riskMap;
        }

        public void getConnectionWithGreatestRisk(Route chosenRoute, RouteTask aiTask, int playerId)
        {
            clearRisk();
            foreach (Connection connection in chosenRoute.Connections)
            {
                if (connection.Weight == 0)
                {
                    continue;
                }
                int originalWeight = connection.Weight;
                _riskMap.setWeight(connection, 9999);
                ShortestPathGenerator shortestPath = new ShortestPathGenerator(_riskMap.getLocations(), _riskMap.getConnections());
                Dictionary<Location, Route> _shortestLocations = shortestPath.CalculateMinCost(aiTask.getStartLocation(), playerId);
                int routeCost = _shortestLocations[aiTask.getEndLocation()].Cost;
                setRisk(connection, routeCost);
                _riskMap.setWeight(connection, originalWeight);
            }
        }


        private void clearRisk()
        {
            foreach (Connection connection in _riskMap.getConnections())
            {
                connection.Risk = 0;
            }
        }


        private void setRisk(Connection connectionToCheck, int risk)
        {
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
