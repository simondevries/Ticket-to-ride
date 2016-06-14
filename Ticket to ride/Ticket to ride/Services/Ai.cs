using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    class Ai: Player
    {


        public Ai(Location startLocation, Location endLocation, int id, Brush colour)
        {
            this._task = new RouteTask(startLocation, endLocation);
            this._playerType = PlayerType.Ai;
            this._id = id;
            this._colour = colour;
        }

        public void performTurn(Map map)
        {
            ShortestPathGenerator shortestPath = new ShortestPathGenerator(map.getLocations(), map.getConnections());
            Dictionary<Location, Route> _shortestLocations = shortestPath.CalculateMinCost(this._task.getStartLocation());
            Route chosenRoute = _shortestLocations[this._task.getEndLocation()];

            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            riskMapGenerator.getConnectionWithGreatestRisk(chosenRoute, this._task);

            //does this update the risk here ?
            Connection trainPlacement = TrainPlacementDecider.placeTrain(map);
            TrianPlacer.placeTrain(trainPlacement, map, this);

        }
    }
}
