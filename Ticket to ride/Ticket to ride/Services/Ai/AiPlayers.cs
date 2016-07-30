namespace Ticket_to_ride.Services.Ai
{
    public class AiPlayerPersonalities : IAiPlayerPersonality
    {
        public int RiskDifferenceBetweenConnectionsToConsiderWorthOfSavingUpFor()
        {
            return 5;
        }

        public int NumberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpFourCards()
        {
            return 30;
        }
        public int NumberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpThreeCards()
        {
            return 20;
        }
        public int NumberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpTwoCards()
        {
            return 10;
        }
    }
}