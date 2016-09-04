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

    //todo separate game from game coordinator
    public class Game : IGame
    {

        TurnCoordinator _turnCoordinator;
        List<Player> _players;
        TrainDeck _trainDeck;
        Map _map;
        ScoreCalculator _scoreCalculator;
        private Logger _gameLog;
        private Guid _gameGuid;
        private GameLoader _gameLoader;
        private RouteCardDeckCoordinator _routeCardDeckCoordinator;
        private readonly RouteDeckRepository _routeDeckRepository;


        public Game()
        {
            _routeCardDeckCoordinator = new RouteCardDeckCoordinator();
            _routeDeckRepository = new RouteDeckRepository();

            _players = new List<Player>();
            _gameLog = new Logger();
            _map = new MapGenerator().CreateMap();
            _trainDeck = new TrainDeck();
            _routeCardDeckCoordinator.BuildRouteCardDeck();
            _gameGuid = Guid.NewGuid();
            _gameLoader = new GameLoader();
        }

        public Game(TrainDeck trainDeck)
        {
            _trainDeck = trainDeck;
        }

        //todo make load

        public IGame Start(int numberOfAi, int numberOfHumans)
        {

            _trainDeck.DealFaceUpCards();

            _scoreCalculator = new ScoreCalculator(_map, numberOfHumans + numberOfAi);
            _turnCoordinator = new TurnCoordinator(_map, _scoreCalculator, _gameLog);
            PlayersBuilder playersBuilder = new PlayersBuilder(_trainDeck,_map, _gameLog);
            _players = playersBuilder.WithAi(numberOfAi).WithHumans(numberOfHumans).Build();
            _turnCoordinator.SetPlayers(_players);
            return this;
        }

        public void SendTrainPlacement(Connection connection)
        {
            Human currentTurnPlayer = (Human)_turnCoordinator.GetCurrentTurnPlayer(_players);
            currentTurnPlayer.PerformTurn(_map, connection, _turnCoordinator,_players);
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

        public void NextTurn()
        {
            _turnCoordinator.NextTurn(_players, _gameLog);
        }


        public void PerformAiTurn()
        {
            Ai.Ai a = (Ai.Ai)_turnCoordinator.GetCurrentTurnPlayer(_players);

            List<int> numberOfTrainsOtherPlayersHave = new List<int>();
            foreach (Player player in _players)
            {
                numberOfTrainsOtherPlayersHave.Add(player._availableTrains);
            }


            a.PerformTurn(_map, numberOfTrainsOtherPlayersHave, _gameLog, _players);
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
            return _turnCoordinator.GetCurrentTurnPlayer(_players)._id;
        }

        public void PlayerPickedFromTop()
        {
            bool tryPickFromTopSucceeds = _turnCoordinator.GetCurrentTurnPlayer(_players)._playerTrainHand.TryPickFromTop(_trainDeck);
            if (tryPickFromTopSucceeds)
            {
                _turnCoordinator.DecrementMoveAndTryProgressTurn(_players);
            }
            Console.WriteLine("No cards in Deck");
        }

        public void PickRouteCards()
        {
            RouteCardDeck routeDeck = _routeDeckRepository.Load();

            _turnCoordinator.GetCurrentTurnPlayer(_players)._playerRouteHand.AddRoutes(routeDeck.PullNonStartingFourRouteCardsForHuman());
            _turnCoordinator.NextTurn(_players,_gameLog); 
            _routeDeckRepository.Update(routeDeck);
        }

        public void PickFaceUpCard(int index)
        {
            bool tryPickFaceUpCard = _turnCoordinator.GetCurrentTurnPlayer(_players)._playerTrainHand.TryPickFaceUpCard(index);
            if (tryPickFaceUpCard)
            {
                _turnCoordinator.DecrementMoveAndTryProgressTurn(_players);
            }
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


        public void Update()
        {


            _gameLoader.Update(_map, _trainDeck, _turnCoordinator, _players);
        }

        public void Load()
        {
           Tuple<Map,TrainDeck,TurnCoordinator,List<Player>>  game = _gameLoader.Load(_map, _trainDeck, _turnCoordinator, _players);
            _map = game.Item1;
            _trainDeck = game.Item2;
            _turnCoordinator = game.Item3;
            _players = game.Item4;
        }
    }
}
