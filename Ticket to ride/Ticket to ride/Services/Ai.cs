using System;
using System.Drawing;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class Ai : Player
    {
        private readonly AiRouteCoordinator _aiRouteGenerator;


        public Ai(PlayerRouteHand playerRouteHand, int id, Brush colour, TrainDeck trainDeck)
            : base(trainDeck)
        {
            PlayerRouteHand = playerRouteHand;
            _playerType = PlayerType.Ai;
            _id = id;
            _colour = colour;
            _aiRouteGenerator = new AiRouteCoordinator(this);
        }

        public void PerformTurn(Map map)
        {
            Route choosenRoute = _aiRouteGenerator.GenerateRoute(map);

            Console.WriteLine(choosenRoute.ToString());
            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            riskMapGenerator.getConnectionWithGreatestRisk(choosenRoute, _id);
            Connection trainPlacement = TrainPlacementDecider.PlaceTrain(map);
            bool placeTrain = TrianPlacer.PlaceTrain(trainPlacement, map, this);

            if (placeTrain == false)
            {
                Console.WriteLine("Computer failed to place train");
            }
        }


    }
}
