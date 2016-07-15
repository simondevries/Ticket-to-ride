using System;
using System.Drawing;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services
{
    public class Ai : Player
    {
        private readonly AiRouteCoordinator _aiRouteCoordinator;


        public Ai(PlayerRouteHand playerRouteHand, int id, Brush colour, TrainDeck trainDeck)
            : base(trainDeck)
        {
            PlayerRouteHand = playerRouteHand;
            _playerType = PlayerType.Ai;
            _id = id;
            _colour = colour;
            _aiRouteCoordinator = new AiRouteCoordinator(this);
        }

        public void PerformTurn(Map map)
        {
            Route choosenRoute = _aiRouteCoordinator.GenerateRoute(map);

            Console.WriteLine(choosenRoute.ToString());
            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            riskMapGenerator.GetConnectionWithGreatestRisk(PlayerRouteHand, choosenRoute, _id);
            Connection trainPlacement = TrainPlacementDecider.PlaceTrain(map);
            bool placeTrain = TrianPlacer.PlaceTrain(trainPlacement, map, this);

            if (placeTrain == false)
            {
                Console.WriteLine("Computer failed to place train");
            }
        }


    }
}
