using System.Drawing;

namespace Ticket_to_ride.Model
{
    public class Player
    {
        private const int NUMBER_OF_TRAINS_AT_START = 30;

        //todo convert to properties?

        public PlayerRouteHand PlayerRouteHand;
        public PlayerType _playerType;
        public int _id;
        public Brush _colour;
        public PlayerTrainHand PlayerTrainHand;
        public int _availableTrains;

        public bool HasFinished { get; set; }

        public Player(TrainDeck trainDeck)
        {
            PlayerTrainHand = new PlayerTrainHand(trainDeck);
            _availableTrains = NUMBER_OF_TRAINS_AT_START;
        }

        public Player(PlayerType playerType, int id, Brush colour)
        {
            _playerType = playerType;
            _id = id;
            _colour = colour;
        }

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
