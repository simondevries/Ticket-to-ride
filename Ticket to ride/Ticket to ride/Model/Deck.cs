using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Services;
namespace Ticket_to_ride.Model
{
    class Deck
    {
        private List<CardType> _deck = new List<CardType>();
        private List<CardType> _cardTypes = new List<CardType>();
        public List<CardType> _onBoard = new List<CardType>();

        public Deck()
        {
            _cardTypes.Add(CardType.Black);
            _cardTypes.Add(CardType.White);
            _cardTypes.Add(CardType.Red);
            _cardTypes.Add(CardType.Green);
            _cardTypes.Add(CardType.Orange);
            _cardTypes.Add(CardType.Wildcard);


            foreach (var type in _cardTypes)
            {
                for (int i = 0; i < 5; i++)
                {
                    _deck.Add(type);
                }
            }

            _deck.Shuffle();

            for (int i = 0; i < 5; i++)
            {
                _onBoard.Add(pickCard());
            }
        }

        public void dealHands(List<Player> players)
        {
            foreach (var player in players)
            {
                for(int i =0;i<4;i++){
                    player._hand.addCard(pickCard());

                }
            }

        }

        public CardType pickCard()
        {
            CardType cardToReturn = _deck[0];
            _deck.RemoveAt(0);
            return cardToReturn;
        }

        public override string ToString()
        {
            string output = "";
            foreach (var type in _cardTypes)
            {
                int numberOfCards = _deck.Select(card => card == type).Count();
                output += "Type" + type + ": " + numberOfCards;
            }
            return output;
        }



    }


}

