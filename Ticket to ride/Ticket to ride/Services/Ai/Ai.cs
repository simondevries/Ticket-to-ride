using System;
using System.Collections.Generic;
using System.Drawing;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services.Ai
{
    public class Ai : Player
    {
        private readonly AiRouteCoordinator _aiRouteCoordinator;
        private readonly IAiPlayerPersonality _aiPlayerPersonality;
        private readonly AiTurnDecider _aiTurnDecider;
        private readonly AiTrainCardPicker _aiTrainCardPicker;
        private readonly TrainDeck _gameTrainDeck;
        private readonly TurnCoordinator _turnCoordinator;

        public Ai(PlayerRouteHand playerRouteHand, int id, Brush colour, TrainDeck trainDeck, IAiPlayerPersonality aiPlayerPersonality, TurnCoordinator turnCoordinator)
            : base(trainDeck)
        {
            PlayerRouteHand = playerRouteHand;
            _playerType = PlayerType.Ai;
            _id = id;
            _colour = colour;
            _aiRouteCoordinator = new AiRouteCoordinator(this);
            _aiTurnDecider = new AiTurnDecider();
            _aiTrainCardPicker = new AiTrainCardPicker();
            _aiPlayerPersonality = aiPlayerPersonality;
            _gameTrainDeck = trainDeck;
            _turnCoordinator = turnCoordinator;
        }

        public void PerformTurn(Map map)
        {
            Route choosenRoute = _aiRouteCoordinator.GenerateRoute(map);

            Console.WriteLine(choosenRoute.ToString());
            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            riskMapGenerator.GetConnectionWithGreatestRisk(PlayerRouteHand, choosenRoute, _id);
            PlayerTrainHand = _aiTurnDecider.PerformTurn(map, PlayerTrainHand, _aiPlayerPersonality, this, _gameTrainDeck);
            if (Settings.AutoAiTurn)
            {
                _turnCoordinator.NextTurn();
            }
        }


    }
}
