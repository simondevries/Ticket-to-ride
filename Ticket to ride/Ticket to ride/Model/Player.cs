using System.Collections.Generic;
using System.Drawing;

namespace Ticket_to_ride.Model
{

    public class Player
    {
        public const int NUMBER_OF_TRAINS_AT_START = 30;

        //todo convert to properties?

        public PlayerRouteHand _playerRouteHand;
        public PlayerType _playerType;
        public int _id;
        public Brush _colour;
        public PlayerTrainHand _playerTrainHand;
        public int _availableTrains;

        public bool HasFinished { get; set; }

        
        public void UseTrains(int trainsBeingUsed)
        {
            _availableTrains -= trainsBeingUsed;

            if (_availableTrains <= 2)
            {
                HasFinished = true;
            }
        }

    }
}
