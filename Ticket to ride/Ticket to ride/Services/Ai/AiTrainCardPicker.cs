using System.Collections.Generic;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.Services.Ai
{
    public class AiTrainCardPicker
    {
        public void PickCard(TrainDeck trainDeck, List<Connection> connectionsOverRiskTollerance, PlayerTrainHand hand)
        {
            int moves = 0;
            List<Connection> cardsToRemove = new List<Connection>();
            foreach (Connection connection in connectionsOverRiskTollerance)
            {
                CardType cardTypeFromConnectionColour = ConnectionColourComparer.GetCardTypeFromConnectionColour(connection._colour);
                if (trainDeck.FaceUpBoardContains(cardTypeFromConnectionColour))
                {
                    if (moves++ >= 2)
                    {
                        return;
                    };
                    hand.AddCard(trainDeck.PickFaceUpCard(cardTypeFromConnectionColour));
                    cardsToRemove.Add(connection);
                }
            }

            //repeat untill out of moves
            while (moves++ < 2)
            {
                hand.AddCard(trainDeck.PickTopCard());
            }
        }
    }
}