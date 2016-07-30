using System.Collections.Generic;
using System.Linq;

namespace Ticket_to_ride.Services.Ai
{
    public class AiNumberOfCardsToPickUpDecider
    {
        public int ShouldPickUpMoreCards(List<int> numberOfTrainsOtherPlayersHave, AiPlayerPersonalities aiPlayerPersonality)
        {
            int minNumberOfTrainsOtherPlayersHave = numberOfTrainsOtherPlayersHave.Min();

            if (minNumberOfTrainsOtherPlayersHave <
                aiPlayerPersonality.NumberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpTwoCards())
            {
                return 2;
            }
            if (minNumberOfTrainsOtherPlayersHave <
                aiPlayerPersonality.NumberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpThreeCards())
            {
                return 3;
            }
            if (minNumberOfTrainsOtherPlayersHave <
                aiPlayerPersonality.NumberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpFourCards())
            {
                return 4;
            }
            return 4;
        }
    }
}