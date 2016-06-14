using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Model;
namespace Ticket_to_ride.Services
{
    class Game
    {
        TurnCoordinator turn;
        Map map;
        Ai computerOne;
        Ai computerTwo;
        Human humanOne;
        List<Player> players;
        Deck _deck;

        public void start()
        {
            _deck = new Deck();
            _deck.ToString();


            map = new MapGenerator().CreateMap();
            players = new List<Player>();
            players.Add(new Ai(map.getLocation(0), map.getLocation(4), 0, BrushBuilder.playerOne()));
            players.Add(new Ai(map.getLocation(1), map.getLocation(3), 1, BrushBuilder.playerTwo()));
          //  players.Add(new Ai(map.getLocation(18), map.getLocation(22), 1, BrushBuilder.playerTwo()));
          //  humanOne = new Human(map.getLocation(11), map.getLocation(5), 1, BrushBuilder.playerFive());
          //  players.Add(humanOne);

            _deck.dealHands(players);

            turn = new TurnCoordinator(players, map);
        }




        public void sendTrainPlacement(Connection connection)
        {
            humanOne.performTurn(map, connection);
            turn.progressTurn();
            //if (turn == 0)
            //{

            //}
            //else
            //{

            //}
        }

        public Map getMap()
        {
            return map;
        }

        public void nextTurn()
        {
            turn.nextTurn();
        }

        public PlayerType getTurn()
        {
            return turn.getCurrentTurn();
        }

    }
}
