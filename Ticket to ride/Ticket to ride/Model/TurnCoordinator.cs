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

        public TurnCoordinator(List<Player> players, Map map)
        {
            _players = players;
            _map = map;
        }

        public void nextTurn()
        {
            if (turn >= _players.Count)
            {
                turn = 0;
            }
            _currentTurn = _players[turn]._playerType;
            if (_currentTurn == PlayerType.Human)
            {
                //Do noting
                Console.WriteLine("Please perform an action");
            }
            else
            {
                Ai a = (Ai)_players[turn];
                a.performTurn(_map);
                progressTurn();
            }
        }

        public void progressTurn(){
            turn++;
        }

        public PlayerType getCurrentTurn()
        {
            return _currentTurn;
        }
    }
}