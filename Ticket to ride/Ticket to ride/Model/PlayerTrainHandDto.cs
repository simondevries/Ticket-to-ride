using System.Collections.Generic;
using System.Linq;

namespace Ticket_to_ride.Model
{
    public class PlayerTrainHandDto
    {
        public List<int> cards { get; set; }

        public PlayerTrainHand Map()
        {
            List<CardType> cardTypes = cards.Select(card => (CardType) card).ToList();

            return new PlayerTrainHand(cardTypes);
        }
    }
}