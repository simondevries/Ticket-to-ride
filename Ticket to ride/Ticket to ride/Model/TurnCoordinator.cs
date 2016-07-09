using System;
using System.Collections.Generic;
using System.Windows;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    class TurnCoordinator
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

        public TurnCoordinator(List<Player> players, Map map)
        {
            _players = players;
            _currentTurn = players[0]._playerType;
            _map = map;
            _movesLeftInTurn = TOTAL_CARD_DRAWS;
        }

        public void NextTurn()
        {
            MessageBox.Show("Next Turn");

            CheckIfLastTurn();
            IncrementTurn();
            _movesLeftInTurn = 2;
            _currentTurn = _players[turn]._playerType;
            if (_currentTurn == PlayerType.Human)
            {
                //Do noting
                Console.WriteLine("Please perform an action");
            }
            else
            {
                Ai a = (Ai)_players[turn];
                a.PerformTurn(_map);
            }
        }

        private void CheckIfLastTurn()
        {
            if (_isLastRound && lastRoundPlayerId == _players[turn]._id)
            {
                MessageBox.Show("Game Over");

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