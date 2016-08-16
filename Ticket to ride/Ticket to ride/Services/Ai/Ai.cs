using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services.Ai
{
    public class Ai : Player
    {
        private readonly AiRouteCoordinator _aiRouteCoordinator;
        private readonly AiPlayerPersonalities _aiPlayerPersonality;
        private readonly AiTurnDecider _aiTurnDecider;
        private readonly AiTrainCardPicker _aiTrainCardPicker;
        private readonly TrainDeck _gameTrainDeck;
        private readonly TurnCoordinator _turnCoordinator;
        private readonly RouteCardDeck _routeCardDeck;
        public readonly PlayerRouteHand _finishdRouteCards;

        public Ai(PlayerRouteHand playerRouteHand, int id, Brush colour, TrainDeck trainDeck, AiPlayerPersonalities aiPlayerPersonality, TurnCoordinator turnCoordinator, RouteCardDeck routeCardDeck)
            : base(trainDeck)
        {
            PlayerRouteHand = playerRouteHand;
            _playerType = PlayerType.Ai;
            _id = id;
            _colour = colour;
            _aiRouteCoordinator = new AiRouteCoordinator();
            _aiTurnDecider = new AiTurnDecider();
            _aiTrainCardPicker = new AiTrainCardPicker();
            _aiPlayerPersonality = aiPlayerPersonality;
            _gameTrainDeck = trainDeck;
            _turnCoordinator = turnCoordinator;
            _routeCardDeck = routeCardDeck;
            _finishdRouteCards = new PlayerRouteHand();
        }

        public void PerformTurn(Map map, List<int> numberOfTrainsOtherPlayersHave, Logger gameLog)
        {
 
            //your sample code
            Route choosenRoute = _aiRouteCoordinator.GenerateRoute(map, _id, PlayerRouteHand.GetAllLocations(), gameLog);


            Console.WriteLine(choosenRoute.ToString());


            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            riskMapGenerator.GetConnectionWithGreatestRisk(PlayerRouteHand, choosenRoute, _id);

            PlayerTrainHand = _aiTurnDecider.PerformTurn(_finishdRouteCards, map, PlayerTrainHand, _aiPlayerPersonality, this, _gameTrainDeck, _routeCardDeck, PlayerRouteHand, numberOfTrainsOtherPlayersHave, gameLog);


            if (Settings.AutoAiTurn)
            {
                _turnCoordinator.NextTurn();
            }
        }

        public PlayerRouteHand GetFinishedRouteHand
        {
            get { return  _finishdRouteCards; }
        }


    }
}
