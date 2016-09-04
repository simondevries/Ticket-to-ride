using System;
using System.Collections.Generic;
using System.Windows;
using Ticket_to_ride.Repository;
using Ticket_to_ride.Services;
using Ticket_to_ride.Services.Ai;

namespace Ticket_to_ride.Model
{
    public class TurnDto
    {
        public int CurrentTurn { get; set; }
        public int Turn { get; set; }
        public bool IsLastTurn { get; set; }
        public int LastRoundPlayerId { get; set; }
        public int MovesLeftInTurn { get; set; }

        public TurnCoordinator Map()
        {
            return new TurnCoordinator((PlayerType)CurrentTurn, Turn, IsLastTurn, LastRoundPlayerId, MovesLeftInTurn);
        }
    }

    public class TurnCoordinator
    {
        PlayerType _currentTurn;
        int _turn;
        private bool _isLastRound;
        private int _lastRoundPlayerId;
        private int _movesLeftInTurn;

        private const int TOTAL_CARD_DRAWS = 2;
        private readonly Map _map;
        private ScoreCalculator _scoreCalculator;
        private Logger _gameLog;
        private MapRepository _mapRepository;

        public TurnCoordinator(PlayerType currentTurn, int turn, bool isLastRound, int lastRoundPlayerId,
            int movesLeftInTurn)
        {
            _currentTurn = currentTurn;
            _turn = turn;
            _isLastRound = isLastRound;
            _lastRoundPlayerId = lastRoundPlayerId;
            _movesLeftInTurn = movesLeftInTurn;
            _mapRepository=new MapRepository();
        }

        public TurnCoordinator(Map map, ScoreCalculator scoreCalculator, Logger gameLog)
        {
            _scoreCalculator = scoreCalculator;
            _gameLog = gameLog;
            _map = map;
            _movesLeftInTurn = TOTAL_CARD_DRAWS;
            _mapRepository = new MapRepository();
        }

        public TurnCoordinator()
        {
        }

        public void SetPlayers(List<Player> players)
        {
            _currentTurn = players[0]._playerType;
        }

        public void NextTurn(List<Player> players, Logger gameLog)
        {
            //todo clean up game log
            _gameLog = gameLog;
            MessageBox.Show("Next Turn");

            CheckIfLastTurn(players);
            IncrementTurn(players);
            _movesLeftInTurn = 2;
            _currentTurn = players[_turn]._playerType;
            if (Settings.AutoAiTurn)
            {
                CheckIfNeedToPlayAiTurn(players);
            }
        }

        private void CheckIfNeedToPlayAiTurn(List<Player> players)
        {
            if (_currentTurn == PlayerType.Ai)
            {
                Ai ai = (Ai) players[_turn];

                List<int> numberOfTrainsOtherPlayersHave = GetNumberOfTrainsOtherPlayersHave(players);

                Map map = _mapRepository.Load();
                ai.PerformTurn(map, numberOfTrainsOtherPlayersHave, _gameLog, players);
                _mapRepository.Update(map);
            }
        }

        private List<int> GetNumberOfTrainsOtherPlayersHave(List<Player> players)
        {
            List<int> numberOfTrainsOtherPlayersHave = new List<int>();
            foreach (Player player in players)
            {
                numberOfTrainsOtherPlayersHave.Add(player._availableTrains);
            }
            return numberOfTrainsOtherPlayersHave;
        }

        private void CheckIfLastTurn(List<Player> players)
        {
            if (_isLastRound && _lastRoundPlayerId == players[_turn]._id)
            {
                MessageBox.Show("Game Over");
                MessageBox.Show(_scoreCalculator.CalculateEndGameScore(players));
            }

            if (players[_turn].HasFinished)
            {
                if (players[_turn]._id == _lastRoundPlayerId)
                {
                    MessageBox.Show("Last round");
                    
                }
                _isLastRound = true;
                _lastRoundPlayerId = players[_turn]._id;
            }

        }

        public void DecrementMove()
        {
            _movesLeftInTurn--;
        }


        public bool HasMovesLeft()
        {
            if (_movesLeftInTurn <= 0)
            {
                return true;
            }
            return false;
        }

        public void DecrementMoveAndTryProgressTurn(List<Player> players)
        {
            DecrementMove();
            if (_movesLeftInTurn <= 0)
            {
                NextTurn(players, _gameLog);
            }
        }

        private void IncrementTurn(List<Player> players)
        {
            if (_turn + 1 >= players.Count)
            {
                _turn = 0;
            }
            else
            {
                ProgressTurn();
            }
        }

        public void ProgressTurn(){
            _turn++;
        }

        public PlayerType GetCurrentTurnPlayerType()
        {
            if (Settings.UsingApi)
            {
                TurnRepository repository = new TurnRepository();
                TurnCoordinator turnCoordinator = repository.Load();

                return turnCoordinator._currentTurn;
            }
            else
            {
                return _currentTurn;
            }
        }


        public Player GetCurrentTurnPlayer(List<Player> players)
        {
            if (_turn < players.Count)
            {
                return players[_turn];
            }
            return null;
        }

        public TurnDto Map()
        {
            return new TurnDto
            {
                Turn = _turn
            };
        }
    }
}