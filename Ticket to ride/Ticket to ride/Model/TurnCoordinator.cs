using System;
using System.Collections.Generic;
using System.Windows;
using Ticket_to_ride.Services;
using Ticket_to_ride.Services.Ai;

namespace Ticket_to_ride.Model
{
    public class TurnCoordinator
    {
        PlayerType _currentTurn;
        List<Player> _players;
        List<PlayerType> _playertypes;
        int turn;
        private bool _isLastRound;
        private int lastRoundPlayerId;
        private readonly Map _map;
        private int _movesLeftInTurn;
        private const int TOTAL_CARD_DRAWS = 2;
        private ScoreCalculator _scoreCalculator;

        public TurnCoordinator( Map map, ScoreCalculator scoreCalculator)
        {
            _scoreCalculator = scoreCalculator;
            _players = new List<Player>();
            _map = map;
            _movesLeftInTurn = TOTAL_CARD_DRAWS;
        }

        public void SetPlayers(List<Player> players)
        {
            _players = players;
            _currentTurn = players[0]._playerType;
        }

        public void NextTurn()
        {
            MessageBox.Show("Next Turn");

            CheckIfLastTurn();
            IncrementTurn();
            _movesLeftInTurn = 2;
            _currentTurn = _players[turn]._playerType;
            if (Settings.AutoAiTurn)
            {
                CheckIfNeedToPlayAiTurn();
            }
        }

        private void CheckIfNeedToPlayAiTurn()
        {
            if (_currentTurn == PlayerType.Ai)
            {
                Ai a = (Ai) _players[turn];
                a.PerformTurn(_map);
            }
        }

        private void CheckIfLastTurn()
        {
            if (_isLastRound && lastRoundPlayerId == _players[turn]._id)
            {
                MessageBox.Show("Game Over");
                MessageBox.Show(_scoreCalculator.CalculateEndGameScore(_players));
            }

            if (_players[turn].HasFinished)
            {
                if (_players[turn]._id == lastRoundPlayerId)
                {
                    MessageBox.Show("Last round");
                    
                }
                _isLastRound = true;
                lastRoundPlayerId = _players[turn]._id;
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

        public void DecrementMoveAndTryProgressTurn()
        {
            DecrementMove();
            if (_movesLeftInTurn <= 0)
            {
                NextTurn();
            }
        }

        private void IncrementTurn()
        {
            if (turn + 1 >= _players.Count)
            {
                turn = 0;
            }
            else
            {
                ProgressTurn();
            }
        }

        public void ProgressTurn(){
            turn++;
        }

        public PlayerType GetCurrentTurnPlayerType()
        {
            return _currentTurn;
        }


        public Player GetCurrentTurnPlayer()
        {
            if (turn < _players.Count)
            {
                return _players[turn];
            }
            return null;
        }
    }
}