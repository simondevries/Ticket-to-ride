using System;
using System.Collections.Generic;
using System.Drawing;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;

namespace Ticket_to_ride.Services.Ai
{

    public class AiDto
    {
        //Player
        public PlayerRouteHandDto PlayerRouteHandDto { get; set; }
        public int PlayerType { get; set; }
        public int Id { get; set; }
        public string Colour { get; set; }
        public PlayerTrainHandDto PlayerTrainHandDto { get; set; }
        public int AvailableTrains { get; set; }

        //Ai Specific
        public AiPlayerPersonalities AiPlayerPersonality { get; set; }
        public PlayerRouteHandDto FinishedRouteCards { get; set; }

        //Used for mapping
        public Ai Map()
        {
            return new Ai(PlayerRouteHandDto.Map(), Id,Color.FromName(Colour), AiPlayerPersonality,  
                PlayerType, PlayerTrainHandDto.Map(), AvailableTrains, FinishedRouteCards.Map());
        }

    }


    public class Ai : Player
    {
        private readonly AiRouteCoordinator _aiRouteCoordinator;
        private readonly AiPlayerPersonalities _aiPlayerPersonality;
        private readonly AiTurnDecider _aiTurnDecider;
        public readonly PlayerRouteHand _finishdRouteCards;

        //Normal constructor
        public Ai(PlayerRouteHand playerRouteHand, int id, Color colour, TrainDeck trainDeck, AiPlayerPersonalities aiPlayerPersonality)
        {
            _playerRouteHand = playerRouteHand;
            _playerType = PlayerType.Ai;
            _id = id;
            _colour = colour;
            _aiRouteCoordinator = new AiRouteCoordinator();
            _aiTurnDecider = new AiTurnDecider();
            _aiPlayerPersonality = aiPlayerPersonality;
            _finishdRouteCards = new PlayerRouteHand();
            _playerTrainHand = new PlayerTrainHand(trainDeck);
            _availableTrains = NUMBER_OF_TRAINS_AT_START;
        }

        //Dto Constructor
        public Ai(PlayerRouteHand playerRouteHand, int id, Color colour, AiPlayerPersonalities aiPlayerPersonality,
            int playerType, PlayerTrainHand playerTrainHand, int availableTrains, PlayerRouteHand finishedRouteCards)
        {
            _playerRouteHand = playerRouteHand;
            _playerType = (PlayerType)playerType;
            _id = id;
            _colour = colour;
            _aiRouteCoordinator = new AiRouteCoordinator();
            _aiTurnDecider = new AiTurnDecider();
            _aiPlayerPersonality = aiPlayerPersonality;
            _playerTrainHand = playerTrainHand;
            _availableTrains = availableTrains;
            _finishdRouteCards = finishedRouteCards;
        }

        //todo I shouldn't be passing players around here
        public void PerformTurn(Map map, List<int> numberOfTrainsOtherPlayersHave, Logger gameLog, List<Player> players, TurnCoordinator turnCoordinator, RouteCardDeck routeCardDeck)
        {
 
            //your sample code
            Route choosenRoute = _aiRouteCoordinator.GenerateRoute(map, _id, _playerRouteHand.GetAllLocations(), gameLog);


            Console.WriteLine(choosenRoute.ToString());


            RiskMapGenerator riskMapGenerator = new RiskMapGenerator(map);
            riskMapGenerator.GetConnectionWithGreatestRisk(_playerRouteHand, choosenRoute, _id);

            _playerTrainHand = _aiTurnDecider.PerformTurn(_finishdRouteCards, map, _playerTrainHand, _aiPlayerPersonality, this, _playerRouteHand, numberOfTrainsOtherPlayersHave, gameLog, routeCardDeck);


            if (Settings.AutoAiTurn)
            {
                turnCoordinator.NextTurn(players, gameLog, routeCardDeck, map);
            }
        }

        public PlayerRouteHand GetFinishedRouteHand
        {
            get { return  _finishdRouteCards; }
        }

        public AiDto Map()
        {
            //todo sdv test mapping
            return new AiDto
            {
                PlayerRouteHandDto = _playerRouteHand.Map(),
                PlayerType = (int) _playerType,
                PlayerTrainHandDto = _playerTrainHand.MapToDto(),
                AiPlayerPersonality = _aiPlayerPersonality,
                Id = _id,
                AvailableTrains = _availableTrains,
                Colour = _colour.Name, //todo sdv test mapping
                FinishedRouteCards = _finishdRouteCards.Map()
            };
        }


    }
}
