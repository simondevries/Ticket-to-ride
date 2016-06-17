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


        public Ai(Location startLocation, Location endLocation, int id, Brush colour, Hand hand)
        {
            _task = new RouteTask(startLocation, endLocation);
            _playerType = PlayerType.Ai;
            _id = id;
            _colour = colour;
            _hand = hand;
        }

        public void PerformTurn(Map map)
        {

            ShortestPathGenerator shortestPath = new ShortestPathGenerator(map.getLocations(), map.getConnections());
            Dictionary<Location, Route> _shortestLocations = shortestPath.CalculateMinCost(this._task.getStartLocation(), this._id);
            Route chosenRoute = _shortestLocations[this._task.getEndLocation()];

            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            riskMapGenerator.getConnectionWithGreatestRisk(chosenRoute, this._task, this._id);

            //does this update the risk here ?
            Connection trainPlacement = TrainPlacementDecider.PlaceTrain(map);
            TrianPlacer.PlaceTrain(trainPlacement, map, this);

        }
    }
}
