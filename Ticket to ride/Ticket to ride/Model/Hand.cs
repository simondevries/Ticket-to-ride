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

        public void addCard(CardType card)
        {
            //placein order??
            _cards.Add(card);
        }

        public bool spendCardsIfPossible(CardType cardType, int quantity){
            List<CardType> availableInHand = _cards.Where(card => card == cardType).ToList();

            if(availableInHand.Count >= quantity){
                foreach (var cardToDiscard in availableInHand)
                {
                    availableInHand.Remove(cardToDiscard);
                }
                return true;
            }else{
                return false;
            }
        }
    }
}
