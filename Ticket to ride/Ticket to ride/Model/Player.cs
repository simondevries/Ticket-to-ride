    using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
   public class Player
   {
       public RouteTask _task;
        public PlayerType _playerType;
        public int _id;
        public Brush _colour;

        public Player()
        {

        }

        public Player(PlayerType playerType, int id, Brush colour)
        {
            _playerType = playerType;
            _id = id;
            _colour = colour;
        }

    }
}
