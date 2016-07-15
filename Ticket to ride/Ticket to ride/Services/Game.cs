using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;
namespace Ticket_to_ride.Services
{
    public class Game
    {
        TurnCoordinator _turn;
        List<Player> _players;
        readonly TrainDeck _trainDeck;
        readonly Map _map;
        private int _numberOfAi;
        private int _numberOfHumans;
        private readonly RouteCardDeck _routeDeck;
        private ScoreCalculator _scoreCalculator;


        public Game(Map map)
        {
            _players = new List<Player>();

            _map = map;
            _trainDeck = new TrainDeck();
            _routeDeck = new RouteCardDeck(_map);
        }

        public void Start(int numberOfAi, int numberOfHumans)
        {
            _numberOfAi = numberOfAi;
            _numberOfHumans = numberOfHumans;
            PlayersBuilder playersBuilder = new PlayersBuilder(_trainDeck, _routeDeck);
            _players = playersBuilder.WithAi(_numberOfAi).WithHumans(_numberOfHumans).Build();

            _trainDeck.DealFaceUpCards();

            _scoreCalculator = new ScoreCalculator(_map, numberOfHumans + _numberOfAi);

            _turn = new TurnCoordinator(_players, _map, _scoreCalculator);
        }

        public void SendTrainPlacement(Connection connection)
        {
            Human currentTurnPlayer = (Human)_turn.GetCurrentTurnPlayer();
            currentTurnPlayer.PerformTurn(_map, connection, _turn);
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
            _turn.NextTurn();
        }

        public PlayerType GetTurn()
        {
            return _turn.GetCurrentTurnPlayerType();
        }

        public PlayerType GetTurnPlayerType()
        {
            return _turn.GetCurrentTurnPlayerType();
        }


        public int GetPlayerId()
        {
            return _turn.GetCurrentTurnPlayer()._id;
        }

        public void PlayerPickedFromTop()
        {
            bool tryPickFromTopSucceeds = _turn.GetCurrentTurnPlayer().PlayerTrainHand.TryPickFromTop(_trainDeck);
            if (tryPickFromTopSucceeds)
            {
                _turn.DecrementMove();
            }
            Console.WriteLine("No cards in Deck");
        }

        public void PickRouteCards()
        {
            _turn.GetCurrentTurnPlayer().PlayerRouteHand.AddRoutes(_routeDeck.PullNonStartingFourRouteCards());
            _turn.NextTurn();
        }

        public void PickFaceUpCard(int index)
        {
            bool tryPickFaceUpCard = _turn.GetCurrentTurnPlayer().PlayerTrainHand.TryPickFaceUpCard(index);
            if (tryPickFaceUpCard)
            {
                _turn.DecrementMove();
            }
        }

        public int TrainsRemaining()
        {
            return _turn.GetCurrentTurnPlayer()._availableTrains;
        }

        public string GetScoreBoard()
        {
            _scoreCalculator.CalculateScoreDuringGame();
            return _scoreCalculator.GetScoreBoard();
        }
    }
}
