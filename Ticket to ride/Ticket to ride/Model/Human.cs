using System.Collections.Generic;
using System.Drawing;
using Ticket_to_ride.Services;

namespace Ticket_to_ride.Model
{
    public class HumanDto
    {
        //Player
        public PlayerRouteHandDto PlayerRouteHandDto { get; set; }
        public int PlayerType { get; set; }
        public int Id { get; set; }
        public string Colour { get; set; }
        public PlayerTrainHandDto PlayerTrainHandDto { get; set; }
        public int AvailableTrains { get; set; }

        public Human Map()
        {
            return new Human(PlayerRouteHandDto.Map(), Id, new SolidBrush(Color.FromName(Colour)), PlayerTrainHandDto.Map(), PlayerType, AvailableTrains);
        }
    }

   public  class Human : Player
    {
        public Human(PlayerRouteHand playerRouteHand, int id, Brush colour, TrainDeck trainDeck)
        {
            _playerRouteHand = playerRouteHand;
            _playerType = PlayerType.Human;
            _id = id;
            _colour = colour;
            _playerTrainHand = new PlayerTrainHand(trainDeck);
            _availableTrains = NUMBER_OF_TRAINS_AT_START;

        }
        //For DTO mappinmg
        public Human(PlayerRouteHand playerRouteHand, int id, SolidBrush colour, PlayerTrainHand playerTrainHand, int playerType, int availableTrains)
        {
            _playerRouteHand = playerRouteHand;
            _playerType = (PlayerType)playerType;
            _id = id;
            _colour = colour;
            _playerTrainHand = playerTrainHand;
            _availableTrains = availableTrains;
        }

        public void PerformTurn(Map map, Connection trainPlacement, TurnCoordinator turn, List<Player> players)
        {
            //TODO sdv validate cards here instead
            if (TrianPlacer.CanSuccessfullyPlaceTrain(trainPlacement, map, this, null))
            {
                turn.NextTurn(players);
            }
        }

        public HumanDto Map()
        {
            //todo test mapping of colur
            return new HumanDto
            {
                PlayerType = (int) _playerType,
                PlayerRouteHandDto = _playerRouteHand.Map(),
                PlayerTrainHandDto = _playerTrainHand.MapToDto(),
                Id = _id,
                AvailableTrains = _availableTrains,
                Colour = _colour.ToString()
            };
        }
    }

}
