using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Model;
namespace Ticket_to_ride.Services
{
    public class Game
    {
        TurnCoordinator _turn;
        public Map _map;
        Ai _computerOne;
        Ai _computerTwo;
        Human _humanOne;
        List<Hand> _hands;
        List<Player> _players;
        Deck _deck;

        public Game(Map map)
        {
            _map = map;
        }

        public void start()
        {
            InitializeHands();

            _deck = new Deck();

            _players = new List<Player>();
            RouteTasksGenerator routeTasksGenerator = new RouteTasksGenerator();
           // _players.Add(new Ai(_map.getLocation(8), _map.getLocation(18), 0, BrushBuilder.playerOne(), _hands[0]));
          //  _players.Add(new Ai(_map.getLocation(10), _map.getLocation(16), 1, BrushBuilder.playerTwo(), _hands[1]));
         //   _players.Add(new Human(routeTasksGenerator.GenerateRouteTasks(_map, 2), 1, BrushBuilder.PlayerOne(), _hands[0]));
            //_players.Add(new Human(routeTasksGenerator.GenerateRouteTasks(_map, 2), 1, BrushBuilder.PlayerTwo(), _hands[1]));
           
         //    _players.Add(new Ai(routeTasksGenerator.GenerateRouteTasks(_map, 2), 0, BrushBuilder.PlayerTwo(), _hands[1]));
           // _players.Add(new Ai(_map.getLocation(3), _map.getLocation(10), _map.getLocation(7), 1, BrushBuilder.PlayerFour(), _hands[1]));
          //  _players.Add(_humanOne);
            


//            _deck.DealNewBoard();
//            _deck.DealHands(_players);

//            _turn = new TurnCoordinator(_players, _map);
        }

        private void InitializeHands()
        {
            _hands = new List<Hand>();
            for (int i = 0; i < 6; i++)
            {
                _hands.Add(new Hand());
            }
        }


        public void SendTrainPlacement(Connection connection)
        {
            Human currentTurnPlayer = (Human) _turn.GetCurrentTurnPlayer();
            currentTurnPlayer.PerformTurn(_map, connection);
        }

        public Map GetMap()
        {
            return _map;
        }

        public Deck GetDeck()
        {
            return _deck;
        }

        public Hand GetPlayersHand(int playerId)
        {
            return _players
                .Where(player => player._id == playerId)
                .Select(player => player._hand)
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
            return PlayerType.Ai;
        }


        public int GetPlayerId()
        {
            return _turn.GetCurrentTurnPlayer()._id;
        }

        public void PlayerPickedFromTop()
        {
            if (_turn.IsTurnOver() == false)
            {
                _turn.GetCurrentTurnPlayer()._hand.PickFromTop(_deck);
                _turn.DecrementMove();
            }
        }
    }
}
