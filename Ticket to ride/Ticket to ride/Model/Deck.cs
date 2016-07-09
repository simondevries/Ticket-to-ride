using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Services;
namespace Ticket_to_ride.Model
{
    public class Deck
    {
        private List<CardType> _deck = new List<CardType>();
        private List<CardType> _cardTypes = new List<CardType>();
        public List<CardType> _onBoard = new List<CardType>();

        private const int NumberOfCards = 99;
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
                for (int i = 0; i < 50; i++)
                {
                    _deck.Add(type);
                }
            }

            _deck.Shuffle();
        }

        public void CheckIfNeedToDealNewBoard()
        {
            int numberOfWildCards = _onBoard.Count(card => card == CardType.Wildcard);
            if (numberOfWildCards >= 3)
            {
                DealNewBoard();
            }
        }

        public void DealNewBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                _onBoard.Add(PickCard());
            }
            CheckIfNeedToDealNewBoard();
        }

        public void FillBoard()
        {
            while (_onBoard.Count < 5)
            {
             _onBoard.Add(PickCard());
                CheckIfNeedToDealNewBoard();
            }
        }

        public void DealHands(List<Player> players)
        {
            foreach (var player in players)
            {
                for (int i = 0; i < NumberOfCards; i++)
                {
                    player._hand.AddCard(PickCard());
                        
                }
            }
        }

        public CardType PickCard()
        {
            if (_deck.Count > 0)
            {
                CardType cardToReturn = _deck[0];
                _deck.RemoveAt(0);
                return cardToReturn;
            }
            throw new InvalidOperationException();
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

        public List<CardType> OnBoard {
            get { return _onBoard; }
        }

        public int CardsRemaining
        {
            get { return _deck.Count; }
        }
    }
}

