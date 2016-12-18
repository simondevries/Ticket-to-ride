using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    class TurnCoordinator
    {
        PlayerType _currentTurn;
        List<Player> _players;
        List<PlayerType> _playertypes;
        int turn = 0;
        Map _map;
        private int _movesLeft;


        public TurnCoordinator(List<Player> players, Map map)
        {
            _players = players;
            _currentTurn = players[0]._playerType;
            _map = map;
            _movesLeft = 2;
        }

        public void NextTurn()
        {
            IncrementTurn();
            _movesLeft = 2;
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

        public void DecrementMove()
        {
            _movesLeft--;
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

        public bool IsTurnOver()
        {
            return _movesLeft <= 0;
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