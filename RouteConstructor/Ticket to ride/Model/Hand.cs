using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Model
{
    public class Hand
    {
        public Player _owner;
        public List<CardType> _cards;

        public Hand()
        {
            _cards = new List<CardType>();
        }

        public void AddCard(CardType card)
        {
            //placein order??
            _cards.Add(card);
        }

        public void PickFromTop(Deck deck)
        {
            try
            {
                AddCard(deck.PickCard());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Ran out of cards");
            }
        }

        private bool CanAffordConnection(Connection connection)
        {
            int numberOfWildCards = _cards.Count(card => card == CardType.Wildcard);
            int numberOfCardsForColour = _cards.Count(card => ConnectionColourComparer.AreCompadable(connection._colour, card));
            return numberOfCardsForColour >= (connection.Weight - numberOfWildCards);
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
                }
                return true;
            }

            return false;
        }
    }
}
