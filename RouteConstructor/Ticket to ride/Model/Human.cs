using System.Drawing;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    class Human : Player
    {
        public Human(RoutesTasks routeTasks, int id, Brush colour, Hand hand)
        {
            _task = routeTasks;
            _playerType = PlayerType.Human;
            _id = id;
            _colour = colour;
            _hand = hand;
        }

        public void PerformTurn(Map map, Connection trainPlacement)
        {
            //TODO sdv validate cards here instead
            TrianPlacer.PlaceTrain(trainPlacement, map, this);
        }
    }
}
