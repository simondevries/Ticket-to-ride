using System.Drawing;

namespace Ticket_to_ride.Model
{
   public class Player
   {
       private const int NumberOfTrainsAtStart = 30;

       public RoutesTasks _task;
        public PlayerType _playerType;
        public int _id;
        public Brush _colour;
        public Hand _hand;
       public int _availableTrains;

        public Player()
        {
            _hand = new Hand();
            _availableTrains = NumberOfTrainsAtStart;
        }

        public Player(PlayerType playerType, int id, Brush colour)
        {
            _playerType = playerType;
            _id = id;
            _colour = colour;
        }


    }
}
