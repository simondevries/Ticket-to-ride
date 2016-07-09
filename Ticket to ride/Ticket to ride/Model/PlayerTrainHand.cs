using System;
using System.Collections.Generic;
using System.Linq;

namespace Ticket_to_ride.Model
{
    public class PlayerTrainHand
    {
        public Player _owner;
        public List<CardType> _cards;
        public TrainDeck _trainDeck;

        public PlayerTrainHand(TrainDeck trainDeck)
        {
            _cards = new List<CardType>();
            _trainDeck = trainDeck;
        }

        public void AddCard(CardType card)
        {
            //placein order??
            _cards.Add(card);
        }

        public bool TryPickFromTop(TrainDeck trainDeck)
        {
            try
            {
                AddCard(trainDeck.PickTopCard());
                return true;
            }
            catch (NoCardsException)
            {
                Console.WriteLine("Ran out of cards");
                return false;
            }
        }

        public bool SpendCardsIfPossible(Connection connection)
        {
            //todo this is only temoporary for testing
            //            if (_owner._playerType == PlayerType.Ai)
            //            {
            //                return true;
            //            }
            List<CardType> compadableCards = _cards.Where(card => ConnectionColourComparer.AreCompadable(connection._colour, card)).ToList();

            if (compadableCards.Count >= connection.Weight)
            {
                List<CardType> sortedCard = compadableCards.OrderBy(card => card).ToList();
                for(int i = 0; i < connection.Weight; i++)
                {
                    _cards.Remove(sortedCard[i]);
                    _trainDeck.AddToDiscardPile(sortedCard[i]);
                }
                return true;
            }

            return false;
        }

        public bool TryPickFaceUpCard(int index)
        {
            try
            {
                CardType faceUpCardAtIndex = _trainDeck.PickFaceUpCard(index);
                if (faceUpCardAtIndex == CardType.Empty)
                {
                        return false;
                }
                AddCard(faceUpCardAtIndex);
                return true;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Ran out of cards");
            }
            return false;
        }
    }
}
