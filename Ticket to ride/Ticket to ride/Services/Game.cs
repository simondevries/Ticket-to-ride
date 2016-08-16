using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;

namespace Ticket_to_ride.Services
{
    public interface IGame
    {
        IGame Start(int numberOfAi, int numberOfHumans);
        void SendTrainPlacement(Connection connection);
        Map GetMap();
        TrainDeck GetDeck();
        PlayerTrainHand GetPlayersHand(int playerId);
        PlayerRouteHand GetPlayersRouteHand(int playerId);
        void NextTurn();
        void PerformAiTurn();
        PlayerType GetTurn();
        PlayerType GetTurnPlayerType();
        int GetPlayerId();
        void PlayerPickedFromTop();
        void PickRouteCards();
        void PickFaceUpCard(int index);
        int TrainsRemaining();
        string GetScoreBoard();
        Logger getLog();
    }

    public class GameDto
    {
        public int NumberOfHumans { get; set; }
        public int NumberOfAi { get; set; }

        public Game Map()
        {
            return new Game();
        }
    }

    public class RouteCardDeckDto
    {
       // public List<RouteCard> RouteCards { get; set; }
    }

    public class TrainDeckDto
    {
        public List<int> TrainDeck { get; set; }

        public TrainDeck Map()
        {
            return new TrainDeck(TrainDeck);
        }
    }

    public class TurnCoordinatorDto
    {
        public int Turn { get; set; }
    }

    //todo separate game from game coordinator
    public class Game : IGame
    {
        TurnCoordinator _turnCoordinator;
        List<Player> _players;
        readonly TrainDeck _trainDeck;
        readonly Map _map;
        private int _numberOfAi;
        private int _numberOfHumans;
        private readonly RouteCardDeck _routeDeck;
        private ScoreCalculator _scoreCalculator;
        private Logger _gameLog;
        private GameRepository _gameRepository;
        private Guid _gameGuid;

        public Game()
        {   
            _players = new List<Player>();
            _gameLog = new Logger();
            _map = new MapGenerator().CreateMap();
            _trainDeck = new TrainDeck();
            _routeDeck = new RouteCardDeck(_map);
            _gameRepository = new GameRepository();
            _gameGuid = Guid.NewGuid();
        }

        public Game(TrainDeck trainDeck)
        {
            _trainDeck = trainDeck;
        }

        public IGame Start(int numberOfAi, int numberOfHumans)
        {

            _numberOfAi = numberOfAi;
            _numberOfHumans = numberOfHumans;

            _trainDeck.DealFaceUpCards();

            _scoreCalculator = new ScoreCalculator(_map, numberOfHumans + _numberOfAi);
            _turnCoordinator = new TurnCoordinator(_map, _scoreCalculator, _gameLog);
            PlayersBuilder playersBuilder = new PlayersBuilder(_trainDeck, _routeDeck, _turnCoordinator,_map, _gameLog);
            _players = playersBuilder.WithAi(_numberOfAi).WithHumans(_numberOfHumans).Build();
            _turnCoordinator.SetPlayers(_players);
            return this;
        }

        public void SendTrainPlacement(Connection connection)
        {
            Human currentTurnPlayer = (Human)_turnCoordinator.GetCurrentTurnPlayer();
            currentTurnPlayer.PerformTurn(_map, connection, _turnCoordinator);
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
                .Select(player => player.PlayerTrainHand)
                .FirstOrDefault();
        }

        public PlayerRouteHand GetPlayersRouteHand(int playerId)
        {
            return _players
                .Where(player => player._id == playerId)
                .Select(player => player.PlayerRouteHand)
                .FirstOrDefault();
        }

        public void NextTurn()
        {
            _turnCoordinator.NextTurn();
        }


        public void PerformAiTurn()
        {
             Ai.Ai a = (Ai.Ai) _turnCoordinator.GetCurrentTurnPlayer();

            List<int> numberOfTrainsOtherPlayersHave = new List<int>();
            foreach (Player player in _players)
            {
                numberOfTrainsOtherPlayersHave.Add(player._availableTrains);
            }


            a.PerformTurn(_map, numberOfTrainsOtherPlayersHave, _gameLog);
        }

        public PlayerType GetTurn()
        {
            return _turnCoordinator.GetCurrentTurnPlayerType();
        }

        public PlayerType GetTurnPlayerType()
        {
            return _turnCoordinator.GetCurrentTurnPlayerType();
        }


        public int GetPlayerId()
        {
            return _turnCoordinator.GetCurrentTurnPlayer()._id;
        }

        public void PlayerPickedFromTop()
        {
            bool tryPickFromTopSucceeds = _turnCoordinator.GetCurrentTurnPlayer().PlayerTrainHand.TryPickFromTop(_trainDeck);
            if (tryPickFromTopSucceeds)
            {
                _turnCoordinator.DecrementMoveAndTryProgressTurn();
            }
            Console.WriteLine("No cards in Deck");
        }

        public void PickRouteCards()
        {
            _turnCoordinator.GetCurrentTurnPlayer().PlayerRouteHand.AddRoutes(_routeDeck.PullNonStartingFourRouteCardsForHuman());
            _turnCoordinator.NextTurn();
        }

        public void PickFaceUpCard(int index)
        {
            bool tryPickFaceUpCard = _turnCoordinator.GetCurrentTurnPlayer().PlayerTrainHand.TryPickFaceUpCard(index);
            if (tryPickFaceUpCard)
            {
                _turnCoordinator.DecrementMoveAndTryProgressTurn();
            }
        }

        public int TrainsRemaining()
        {
            return _turnCoordinator.GetCurrentTurnPlayer()._availableTrains;
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




        public GameDto Map()
        {
            return new GameDto
            {
                NumberOfAi =  _numberOfAi,
                NumberOfHumans = _numberOfHumans,
                RouteCardDeck = _routeDeck.Map(),
                TrainDeckDto = _trainDeck.Map(),
                TurnCoordinatorDto = _turnCoordinator.Map()
            };
        }
    }
}
