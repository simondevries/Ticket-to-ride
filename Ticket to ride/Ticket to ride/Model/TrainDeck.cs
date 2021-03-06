﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ticket_to_ride.Services;
namespace Ticket_to_ride.Model
{


    public class TrainDeckDto
    {
        public List<int> Deck { get; set; }
        public List<int> CardTypes { get; set; }
        public List<int> FaceUpCards { get; set; }
        public List<int> DiscardPile { get; set; }

        public TrainDeck Map()
        {

            var deck = Deck.Select(card => (CardType)Enum.Parse(typeof(CardType), "" + card)).ToList(); 
            var cardTypes = CardTypes.Select(card => (CardType)Enum.Parse(typeof(CardType), "" + card)).ToList(); 
            var faceUpCards = FaceUpCards.Select(card => (CardType)Enum.Parse(typeof(CardType), "" + card)).ToList(); 
            var discardPile = DiscardPile.Select(card => (CardType)Enum.Parse(typeof(CardType), "" + card)).ToList(); 

            return new TrainDeck(deck, cardTypes, faceUpCards,discardPile);
        }
    }

    public class TrainDeck
    {
        private readonly List<CardType> _deck = new List<CardType>();
        private readonly List<CardType> _cardTypes = new List<CardType>();
        private List<CardType> _faceUpCards = new List<CardType>();
        private readonly List<CardType> _discardPile;

        private const int NUMBER_OF_CARDS_PLAYERS_START_WITH = 5;
        private const int NUMBER_OF_EACH_TYPE_OF_CARD = 10;
        private const int NUMBER_OF_FACEUP_CARDS_ON_BOARD = 5;

        public TrainDeck(List<int> trainDeck)
        {
        }

        /// <summary>
        /// This builds a train deck
        /// </summary>
        public TrainDeck()
        {
            _discardPile = new List<CardType>();

            _cardTypes.Add(CardType.Black);
            _cardTypes.Add(CardType.White);
            _cardTypes.Add(CardType.Red);
            _cardTypes.Add(CardType.Pink);
            _cardTypes.Add(CardType.Orange);
            _cardTypes.Add(CardType.Wildcard);


            foreach (var type in _cardTypes)
            {
                for (int i = 0; i < NUMBER_OF_EACH_TYPE_OF_CARD; i++)
                {
                    _deck.Add(type);
                }
            }

            _deck.Shuffle();
        }

        public TrainDeck(List<CardType> trainDeck, List<CardType> cardTypes, List<CardType> faceUpCards, List<CardType> discardPile)
        {
            _deck = trainDeck;
            _cardTypes = cardTypes;
            _faceUpCards = faceUpCards;
            _discardPile = discardPile;
        }

        public bool FaceUpBoardContains(CardType cardType)
        {
            return FaceUpCards.Contains(cardType);
        }

        public void AddToDiscardPile(CardType card)
        {
            _discardPile.Add(card);
            DealFaceUpCards(); // Incase there are no cards, more the spent card to the board
            Console.WriteLine("Adding card {0} to the discard pile", card);
        }

        public void CheckIfNeedToDealNewBoard()
        {
            int numberOfWildCards = _faceUpCards.Count(card => card == CardType.Wildcard);
            if (numberOfWildCards >= 3)
            {
                _faceUpCards = new List<CardType>();
                DealFaceUpCards();
            }
        }

        public void DealFaceUpCards()
        {
            //Replace cards pulled from the faceup deck
            for (int j = 0; j < _faceUpCards.Count; j++)
            {
                if (_faceUpCards[j] == CardType.Empty)
                {
                    try
                    {
                        _faceUpCards[j] = PickTopCard();
                    }
                    catch (NoCardsException)
                    {
                        _faceUpCards[j] = CardType.Empty;
                    }
                }
            }

            //Update so there are 5 cards
            for (int i = _faceUpCards.Count; i < NUMBER_OF_FACEUP_CARDS_ON_BOARD; i++)
            {
                try
                {
                    _faceUpCards.Add(PickTopCard());
                }
                catch (NoCardsException)
                {
                    _faceUpCards.Add(CardType.Empty);
                }
            }

            //Check for 3 wilds
            CheckIfNeedToDealNewBoard();
        }

        public void DealHands(List<Player> players)
        {
            foreach (var player in players)
            {
                for (int i = 0; i < NUMBER_OF_CARDS_PLAYERS_START_WITH; i++)
                {
                    player._playerTrainHand.AddCard(PickTopCard());
                }   
            }
        }

        public CardType PickTopCard()
        {
            if (_deck.Count <= 0)
            {
                if (_discardPile.Count > 0)
                {
                    _discardPile.Shuffle();
                    _deck.AddRange(_discardPile);
                    _discardPile.Clear();
                }
                else
                {
                    
                    throw new NoCardsException();
                }
            }
            CardType cardToReturn = _deck[0];
                _deck.RemoveAt(0);
                return cardToReturn;
        }


        public CardType PickFaceUpCard(CardType card)
        {
            for (int i = 0; i < FaceUpCards.Count; i++)
            {
                if(FaceUpCards[i] == card)
                return PickFaceUpCard(i);
            }
            return CardType.Empty;
        }

        public CardType PickFaceUpCard(int index)
        {
            CardType selectedCard = _faceUpCards[index];
            if (selectedCard == CardType.Empty)
            {
                return CardType.Empty;
            }
            _faceUpCards[index] = CardType.Empty;
            DealFaceUpCards();

            return selectedCard;
        }

        public List<CardType> FaceUpCards {
            get { return _faceUpCards; }
        }

        public int CardsRemaining
        {
            get { return _deck.Count; }
        }

        public TrainDeckDto Map()
        {
            return new TrainDeckDto
            {
                FaceUpCards = _faceUpCards.Select(card => (int)card).ToList(),
                Deck = _deck.Select(card => (int)card).ToList(),
                CardTypes = _cardTypes.Select(card => (int)card).ToList(),
                DiscardPile = _discardPile.Select(card => (int)card).ToList()
            };
        }
    }
}

