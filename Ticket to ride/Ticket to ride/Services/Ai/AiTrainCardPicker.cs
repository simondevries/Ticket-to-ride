using System.Collections.Generic;
using Ticket_to_ride.Model;
using Ticket_to_ride.Repository;

namespace Ticket_to_ride.Services.Ai
{
    public class AiTrainCardPicker
    {
        private TrainDeckRepository _trainDeckRepository;
        public AiTrainCardPicker()
        {
            _trainDeckRepository = new TrainDeckRepository();
        }

        public void PickCard(List<Connection> connectionsOverRiskTollerance, PlayerTrainHand hand, TrainDeck trainDeck)
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

            _trainDeckRepository.Update(trainDeck);
        }
    }
}