namespace Ticket_to_ride.Services.Ai
{
    public class AiPlayerPersonalities
    {

        public int RiskDifferenceBetweenConnectionsToConsiderWorthOfSavingUpFor {
            get { return 5; }
        }

        public int NumberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpFourCards
        {
            get { return 30; }
        }
        public int NumberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpThreeCards
        {
            get { return 20; }
        }
        public int NumberOfTrainsOtherPlayersNeedToHaveInOrderToPickUpTwoCards
        {
            get { return 10; }
        }
    }
}