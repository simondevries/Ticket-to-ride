using System;
using System.Collections.Generic;
using System.Linq;
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
            //todo (sdv) What if the user builds on an undefined connection?
            if (CanAffordConnection(connection))
            {
                //This is bad because it assumes the user can afford
                int numberRemoved = 0;
                foreach (var card in _cards)
                {


                    if (ConnectionColourComparer.AreCompadable(connection._colour, card))
                    {
                        numberRemoved++;
                        _cards.Remove(card);

                        if (numberRemoved >= connection.Weight)
                        {
                            break;
                        }
                    }
                }

                if (numberRemoved == 0)
                {
                    for (int i = 0; i < connection.Weight; i++)
                    {
                        if (_cards[i] == CardType.Wildcard)
                        {
                            _cards.Remove(_cards[i]);
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
