using System.Collections.Generic;
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

        public void getConnectionWithGreatestRisk(Route chosenRoute,  int playerId)
        {
            clearRisk();

            foreach (DestinationPair destinationPair in chosenRoute.startAndEnd)
            {
                List<Connection> connectionsForSection = new List<Connection>();
                bool start = false;
                foreach (Connection connection in chosenRoute.Connections)
                {
                    if (connection.A == destinationPair.StartLocation)
                    {
                        start = true;
                    }
                    if (connection.A == destinationPair.EndLocation)
                    {
                        break;
                    }

                    if (start)
                    {
                        connectionsForSection.Add(connection);
                    }
                }


                foreach (Connection connection in connectionsForSection)
                {
                    if (connection.Weight == 0)
                    {
                        continue;
                    }
                    int originalWeight = connection.Weight;
                    _riskMap.setWeight(connection, 9999);
                    ShortestPathGenerator shortestPath = new ShortestPathGenerator(_riskMap.getLocations(), _riskMap.getConnections());
                    Dictionary<Location, Route> _shortestLocations = shortestPath.CalculateMinCost(destinationPair.StartLocation, playerId);
                    //todo Cost should be added if route overlap in multiple occasions
                    int routeCost = _shortestLocations[destinationPair.EndLocation].Cost;
                    setRisk(connection, routeCost);
                    
                    _riskMap.setWeight(connection, originalWeight);
                }  
            }

           

//            foreach (Connection connection in chosenRoute.Connections)
//            {
//                if (connection.Weight == 0)
//                {
//                    continue;
//                }
//                int originalWeight = connection.Weight;
//                _riskMap.setWeight(connection, 9999);
//                ShortestPathGenerator shortestPath = new ShortestPathGenerator(_riskMap.getLocations(), _riskMap.getConnections());
//                Dictionary<Location, Route> _shortestLocations = shortestPath.CalculateMinCost(aiCard.GetEndLocation(), playerId);
//                int routeCost = _shortestLocations[aiCard.GetThirdLocation()].Cost;
//                setRisk(connection, routeCost);
//                _riskMap.setWeight(connection, originalWeight);
//            }
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
