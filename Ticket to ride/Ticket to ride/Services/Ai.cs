using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    class Ai
    {
        private RouteTask _aiTask;
        public Ai()
        {

        }

        public Ai(Location startLocation, Location endLocation)
        {
            _aiTask = new RouteTask(startLocation, endLocation);

        }

        public RouteTask getAiTask() { return _aiTask; }

        public void performTurn(Map map)
        {
            ShortestPathGenerator shortestPath = new ShortestPathGenerator(map.getLocations(), map.getConnections());
            Dictionary<Location, Route> _shortestLocations = shortestPath.CalculateMinCost(map.getLocation(0));
            Route chosenRoute = _shortestLocations[_aiTask.getEndLocation()];

            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            riskMapGenerator.getConnectionWithGreatestRisk(chosenRoute, this.getAiTask());

            //does this update the risk here ?
            Connection trainPlacement = TrainPlacementDecider.placeTrain(map);
            TrianPlacer.placeTrain(trainPlacement, map);

        }
    }
}
