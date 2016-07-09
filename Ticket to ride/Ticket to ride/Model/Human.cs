using System.Drawing;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    class Human : Player
    {
        public Human(PlayerRouteHand playerRouteHand, int id, Brush colour, TrainDeck trainDeck) : base(trainDeck)
        {
            PlayerRouteHand = playerRouteHand;
            _playerType = PlayerType.Human;
            _id = id;
            _colour = colour;
                
        }

        public void PerformTurn(Map map, Connection trainPlacement, TurnCoordinator turn)
        {
            //TODO sdv validate cards here instead
            if (TrianPlacer.PlaceTrain(trainPlacement, map, this))
            {
                turn.NextTurn();
            }
        }
    }
}
