using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services.Ai;

namespace Ticket_to_ride.Services
{
    //todo separate game from game coordinator
    public class Game : IGame
    {
        public TurnCoordinator _turnCoordinator;
        public List<Player> _players;
        public TrainDeck _trainDeck;
        public Map _map;
        public RouteCardDeck _routeCardDeck;
        ScoreCalculator _scoreCalculator;
        private Logger _gameLog;
        private Guid _gameGuid;
        private readonly GameRepository _gameRepository = new GameRepository();

        public Game(TurnCoordinator turnCoordinator, List<Player> players, TrainDeck trainDeck, Map map, RouteCardDeck routeCardDeck)
        {
            _turnCoordinator = turnCoordinator;
            _players = players;
            _trainDeck = trainDeck;
            _map = map;
            _routeCardDeck = routeCardDeck;
            _gameLog = new Logger();


            _scoreCalculator = new ScoreCalculator(_map, _turnCoordinator.GetNumberOfHumans(_players) + _turnCoordinator.GetNumberOfAi(_players));
        }

        public Game()
        {
            _players = new List<Player>();
            _gameLog = new Logger();
            _map = new MapGenerator().CreateMap();
            _trainDeck = new TrainDeck();
            _routeCardDeck = new RouteCardDeck(_map);
            _gameGuid = Guid.NewGuid();
            _turnCoordinator = new TurnCoordinator(_map, _scoreCalculator, _gameLog);
            _gameRepository.CacheSave(this);
        }


        //todo make load

        public IGame Start(int numberOfAi, int numberOfHumans)
        {

            _trainDeck.DealFaceUpCards();

            _scoreCalculator = new ScoreCalculator(_map, numberOfHumans + numberOfAi);
            _turnCoordinator = new TurnCoordinator(_map, _scoreCalculator, _gameLog);
            PlayersBuilder playersBuilder = new PlayersBuilder(_trainDeck, _map, _gameLog);
            _players = playersBuilder.WithAi(numberOfAi).WithHumans(numberOfHumans).Build(_routeCardDeck);
            _turnCoordinator.SetPlayers(_players);
            _gameRepository.CacheSave(this);
            return this;
        }

        public List<AiDto> GetAiPlayers()
        {
            List<AiDto> aisPlayers = new List<AiDto>();
            foreach (Player player in _players)
            {
                if (player._playerType == PlayerType.Ai)
                {
                    Ai.Ai aiToAdd = (Ai.Ai)player;
                    aisPlayers.Add(aiToAdd.Map());
                }
            }
            return aisPlayers;
        }

        public List<HumanDto> GetHumanPlayers()
        {
            List<HumanDto> humanPlayers = new List<HumanDto>();
            foreach (Player player in _players)
            {
                if (player._playerType == PlayerType.Human)
                {
                    Human humanToAdd = (Human)player;
                    humanPlayers.Add(humanToAdd.Map());
                }
            }
            return humanPlayers;
        }

        public TurnInformationDto SendTrainPlacement(string connectionIdentity)
        {
            Connection connection = _map.GetConnectionByIdentity(connectionIdentity);
            Human currentTurnPlayer;
            try
            {
                currentTurnPlayer = (Human)_turnCoordinator.GetCurrentTurnPlayer(_players);
            }
            catch (InvalidCastException ex)
            {
                return new TurnInformationDto { PlacementFailedMessage = "It is not a humans turn" };
            }

            bool canPlaceTrain = currentTurnPlayer.PerformTurn(_map, connection, _turnCoordinator, _players, _turnCoordinator, _routeCardDeck, _trainDeck);
            if (!canPlaceTrain)
            {
                return new TurnInformationDto { PlacementFailedMessage = "Cannot place train there" };
            }
            _gameRepository.CacheSave(this);



            return new TurnInformationDto { Connection = connection.Map() };  //success
        }

        public TurnInformationDto TryPlayAiTurn()
        {
            TurnInformationDto checkIfNeedToPlayAiTurn = _turnCoordinator.CheckIfNeedToPlayAiTurn(_players, _routeCardDeck, _map, _trainDeck);
           
            //save taskes place in here
            NextTurn();

            return checkIfNeedToPlayAiTurn;
        }

        public Map GetMap()
        {
            return _map;
        }


        public TrainDeck GetDeck()
        {
            return _trainDeck;
        }

        public PlayerTrainHand GetPlayersHand(int playerId)
        {
            return _players
                .Where(player => player._id == playerId)
                .Select(player => player._playerTrainHand)
                .FirstOrDefault();
        }

        public PlayerRouteHand GetPlayersRouteHand(int playerId)
        {
            return _players
                .Where(player => player._id == playerId)
                .Select(player => player._playerRouteHand)
                .FirstOrDefault();
        }

        private void NextTurn()
        {
            _turnCoordinator.NextTurn(_players, _gameLog, _routeCardDeck, _map, _trainDeck);
            _gameRepository.CacheSave(this);
        }


        public void PerformAiTurn()
        {
            Ai.Ai a = (Ai.Ai)_turnCoordinator.GetCurrentTurnPlayer(_players);

            List<int> numberOfTrainsOtherPlayersHave = new List<int>();
            foreach (Player player in _players)
            {
                numberOfTrainsOtherPlayersHave.Add(player._availableTrains);
            }


            a.PerformTurn(_map, numberOfTrainsOtherPlayersHave, _gameLog, _players, _turnCoordinator, _routeCardDeck, _trainDeck);
            _gameRepository.CacheSave(this);
        }

        public PlayerType GetTurn()
        {
            return _turnCoordinator.GetCurrentTurnPlayerType();
        }
        public PlayerType GetTurnPlayerType()
        {
            return _turnCoordinator.GetCurrentTurnPlayerType();
        }


        public int GetPlayerIdForCurrentTurn()
        {
            return _turnCoordinator.GetCurrentTurnPlayer(_players)._id;
        }
// todo sdv delete?
//        public void PlayerPickedFromTop()
//        {
//            bool tryPickFromTopSucceeds = _turnCoordinator.GetCurrentTurnPlayer(_players)._playerTrainHand.TryPickFromTop(_trainDeck);
//            if (tryPickFromTopSucceeds)
//            {
//                _turnCoordinator.DecrementMovesIndicateNeedToProgressTurn(_players, _routeCardDeck, _map, _trainDeck);
//            }
//            Console.WriteLine("No cards in Deck");
//            _gameRepository.CacheSave(this);
//        }

        public List<RouteCardDto> PullFourRouteCards()
        {
           return  _routeCardDeck.PullNonStartingFourRouteCardsForHuman();
        }

//        public void PickRouteCards()
//        {
//            
//            _turnCoordinator.GetCurrentTurnPlayer(_players)._playerRouteHand.AddRoutes(_routeCardDeck.PullNonStartingFourRouteCardsForHuman());
////            _turnCoordinator.NextTurn(_players, _gameLog, _routeCardDeck, _map, _trainDeck);
//            _gameRepository.CacheSave(this);
//        }

        /// <summary>
        /// Returns if the turn has progressed
        /// </summary>
        public bool PickFaceUpCard(int index)
        {
            bool tryPickFaceUpCard = _turnCoordinator.GetCurrentTurnPlayer(_players)._playerTrainHand.TryPickFaceUpCard(index, _trainDeck);
            bool needsToProgressTurn = false;
            if (tryPickFaceUpCard)
            {
                needsToProgressTurn = _turnCoordinator.DecrementMovesIndicateNeedToProgressTurn(_players, _routeCardDeck, _map, _trainDeck);
            }
            _gameRepository.CacheSave(this);
            return needsToProgressTurn;
        }

        public int TrainsRemaining()
        {
            return _turnCoordinator.GetCurrentTurnPlayer(_players)._availableTrains;
        }

        public string GetScoreBoard()
        {
            _scoreCalculator.CalculateScoreDuringGame();
            return _scoreCalculator.GetScoreBoard();
        }

        public Logger getLog()
        {
            return _gameLog;
        }

        public Guid GetGameGuid()
        {
            return _gameGuid;
        }

        public void Save()
        {
            new GameRepository().Save(this);
        }

        public void SendPlayersSelectedRouteCards(PlayersSelectedRouteCards selectedCards)
        {
            if (selectedCards.PlayerId < _players.Count)
            {
                List<RouteCard> routeCards =
                    selectedCards.SelectedRoutesResponse.Select(routeCard => routeCard.Route.Map()).ToList();

                _players[selectedCards.PlayerId]._playerRouteHand.AddRoutes(routeCards);
            }
        }
    }
}
